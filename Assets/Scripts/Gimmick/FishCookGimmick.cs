using UnityEngine;

//���̒����N���X

public class FishCookGimmick : MonoBehaviour
{
    [SerializeField] Animator animator = default;
    [SerializeField] Item.Type type = default;
    [SerializeField] GameObject ShowItem = default;

    public void FishCook()
    {
        if (ItemBox.instance.CollectItemSelect(type) == false) return;     //��I�����ĂȂ�������return
        if (GimmickStatusManager.instance.setFishGimmick == false) return; //���܂ȔɃZ�b�g���ĂȂ�������return
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
