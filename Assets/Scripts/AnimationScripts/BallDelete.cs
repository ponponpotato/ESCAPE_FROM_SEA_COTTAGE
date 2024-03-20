using UnityEngine;

//捧げ玉のアニメクラス：色が対応している捧げ玉を使用することでアニメ開始、その後、非表示アイテムを表示

public class BallDelete : MonoBehaviour
{

    [SerializeField] Animator animator = default;
    [SerializeField] GameObject Ball = default;
    [SerializeField] GameObject ShowItem = default;
    public Item.Type type;
    public GimmickStatus.Type GimmickType;
    public string AnimName;
    // クリックすると、ボールを消去する

    public void DeleteBall()
    {
        if (ItemBox.instance.CollectItemSelect(type) == true)
        {
            ItemBox.instance.ItemUsed();
            Ball.gameObject.SetActive(true);
            animator.Play(AnimName);
            SoundManager.instance.PlaySound(SoundManager.instance.BallDeleteSound);
            Invoke("ItemShow", 2.5f);
            return;
        }

        if(GimmickStatusManager.instance.StatusCheck(GimmickType) == false)
        {
            MessageShow.instance.ShowMessage("何か不思議な力を感じる");
        }


    }

    void ItemShow()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.PickUpSound);
        Ball.gameObject.SetActive(false);
        ShowItem.gameObject.SetActive(true);
        GimmickStatusManager.instance.StatusChanger(GimmickType);
    }

}

