using UnityEngine;

//魚の調理クラス

public class FishCookGimmick : MonoBehaviour
{
    [SerializeField] Animator animator = default;
    [SerializeField] Item.Type type = default;
    [SerializeField] GameObject ShowItem = default;

    public void FishCook()
    {
        if (ItemBox.instance.CollectItemSelect(type) == false) return;     //包丁選択してなかったらreturn
        if (GimmickStatusManager.instance.setFishGimmick == false) return; //魚まな板にセットしてなかったらreturn
        ItemBox.instance.ItemUsed();
        animator.Play("FishCook");
        Invoke("PlaySound", 0.5f);
        Invoke("ItemShow", 1.0f);
    }

    void PlaySound()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.FishCookSound);
    }

    void ItemShow()
    {
        ShowItem.SetActive(true);
    }

}
