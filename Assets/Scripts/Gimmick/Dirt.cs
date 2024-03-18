using UnityEngine;

//梯子の汚れギミックのクラス

public class Dirt : MonoBehaviour
{
    public GameObject Floor2MoveColider;
    [SerializeField] Animator animator = default;
    
    public void Clean()
    {
        if (ItemBox.instance.CollectItemSelect(Item.Type.Towell)==true)//タオル選択してなかったらリターン
        {
            ItemBox.instance.ItemUsed();
            animator.Play("CleanDirt");
            SoundManager.instance.PlaySound(SoundManager.instance.CleanSound);
            Invoke("ColiderON", 1.5f);
            return;
        }
        MessageShow.instance.ShowMessage("汚れがひどくて登れそうにない");

    }

    //アニメーション終わった後に梯子登るためのコライダーをON
    void ColiderON()
    {
        GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.RemoveDirtGimmick);
        Floor2MoveColider.SetActive(true);
        gameObject.SetActive(false);
    }

}
