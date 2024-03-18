using UnityEngine;

//�����`�����}�b�g�ɗ������Z�b�g����M�~�b�N�̃N���X

public class SetFoodGimmick : MonoBehaviour
{
    [SerializeField] GameObject ShowFoodObj = default;
    [SerializeField] GameObject ShowItemObj = default;
    [SerializeField] GameObject HideObj = default;
    [SerializeField] GameObject HideSlimeObj = default;
    [SerializeField] GameObject SlimeAnimParent = default;
    [SerializeField] GimmickStatus.Type GimmickType = default;
    [SerializeField] Item.Type type = default;
    [SerializeField] Animator animator = default;
    [SerializeField] string animName = default;

    //�Ή������A�C�e���̎g�p�ɉ����ăX���C���̈ړ��A�j�����v���C
    public void SetFood()
    {
        if (ItemBox.instance.CollectItemSelect(type) == false) return;

        if (HideObj != null) HideObj.SetActive(false);

        ItemBox.instance.ItemUsed();
        ShowFoodObj.SetActive(true);
        SlimeAnimParent.SetActive(true);
        HideSlimeObj.SetActive(false);
        ShowItemObj.SetActive(true);
        GimmickStatusManager.instance.StatusChanger(GimmickType);
        animator.Play(animName);
        Invoke("PlaySound", 0.75f);
        Invoke("PlaySound", 1.75f);
    }

    void PlaySound()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.SlimeMoveSound);
    }
}
