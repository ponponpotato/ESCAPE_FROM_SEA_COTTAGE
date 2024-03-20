using UnityEngine;

//�����ʂ̃A�j���N���X�F�F���Ή����Ă�������ʂ��g�p���邱�ƂŃA�j���J�n�A���̌�A��\���A�C�e����\��

public class BallDelete : MonoBehaviour
{

    [SerializeField] Animator animator = default;
    [SerializeField] GameObject Ball = default;
    [SerializeField] GameObject ShowItem = default;
    public Item.Type type;
    public GimmickStatus.Type GimmickType;
    public string AnimName;
    // �N���b�N����ƁA�{�[������������

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
            MessageShow.instance.ShowMessage("�����s�v�c�ȗ͂�������");
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

