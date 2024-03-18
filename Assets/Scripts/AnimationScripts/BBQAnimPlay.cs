using UnityEngine;

//�o�[�x�L���[�Ɋւ���A�j���A�I�u�W�F�N�g�̕\����\���̃N���X�@

public class BBQAnimPlay : MonoBehaviour
{
    [SerializeField] Animator animator = default;
    [SerializeField] Item.Type type = default;
    [SerializeField] GameObject RowMeetObj = default;
    [SerializeField] GameObject OpenAmiObj = default;
    [SerializeField] GameObject WoodObj = default;
    [SerializeField] GameObject SteakObj = default;

    public string AnimName = "";
    bool IsOpen = false;
    bool CanOpen = false;

    //�o�[�x�L���[�O�����̖Ԃ��N���b�N���ĊJ�@�A�C�e���̑I���󋵂ɉ����ĕ���
    public void OnClickObj()
    {

        if (GimmickStatusManager.instance.bbqGimmick == true) return;

        Item item = ItemBox.instance.GetSelectedItem();

        if (item == null)
        {
            Open();
            return;
        }

        switch (item.type)
        {

            case Item.Type.Wood: //�d���I������Ă����ꍇ
                CanOpen = true;
                break;

            case Item.Type.Oil: //�t�̔R�����I������Ă����ꍇ
                CanOpen = true;
                break;

            case Item.Type.Meet: //�����I�����I������Ă����ꍇ
                CanOpen = false;
                MeetShow();
                return;

            case Item.Type.Lighter: //���C�^�[���I������Ă����ꍇ
                if (AnimPlay() == false)
                {
                    CanOpen = true;
                    break;
                }
                return;

            default:
                CanOpen = true;
                break;

        }

        if (CanOpen == true)
        {
            Open();
        }

    }

    // �o�[�x�L���[�O�����̖Ԃ̊J����
    private void Open()
    {
        if(GimmickStatusManager.instance.bbqGimmick == true) return;
        gameObject.SetActive(false);
        OpenAmiObj.SetActive(true);
    }

    // �����I������Ă�����ԂŃo�[�x�L���[�O�����̖Ԃ��N���b�N������A����ԂɃZ�b�g
    private void MeetShow()
    {
        ItemBox.instance.ItemUsed();
        RowMeetObj.SetActive(true);
        SoundManager.instance.PlaySound(SoundManager.instance.PickUpSound);
        GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.SetMeetGimmick);
    }

    // �o�[�x�L���[�̃A�j���@�d�̃Z�b�g�A���̃Z�b�g�A�t�̔R���̓h�z�A���C�^�[�̎g�p���ׂĂ𖞂����ꍇ�Ɏ��s
    public bool AnimPlay()
    {
        if (GimmickStatusManager.instance.setWoodGimmick == false) return false;
        if (GimmickStatusManager.instance.setMeetGimmick == false) return false;
        if (GimmickStatusManager.instance.applyOilGimmick == false)
        {
            MessageShow.instance.ShowMessage("���C�^�[�݂̂ł͐d�ɉ΂�����ꂻ���ɂȂ�");
            return false;
        }

        animator.Play(AnimName);
        RowMeetObj.SetActive(false);
        WoodObj.SetActive(false);
        SoundManager.instance.PlaySound(SoundManager.instance.BBQSound);
        Invoke("ShowSteak", 3.0f);
        return true;
    }

    // ������̃X�e�[�L�\��
    void ShowSteak()
    {
        SteakObj.SetActive(true);
        GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.BBQGimmick);
    }
}
