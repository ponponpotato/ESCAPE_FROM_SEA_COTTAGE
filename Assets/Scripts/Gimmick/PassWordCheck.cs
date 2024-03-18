using UnityEngine;
using UnityEngine.Events;

//�����̃p�X���[�h�ɂȂ��Ă��邩�𔻕�

public class PassWordCheck : MonoBehaviour
{
    //��������ƁA�ݒ肳�ꂽ�C�x���g�����s����iUnityEvent�j
    public UnityEvent ClearEvent;

    [SerializeField] GimmickStatus.Type type = default;

    //����ԍ��̔z�� 
    [SerializeField] int[] CorrectNumbers;

    //���݂̐��l:PassWordButton��Number���Q�Ƃ���΂悢
    [SerializeField] Password_Changer[] PassWordButtons;
    [SerializeField] ImageChanger[] ImageButtons;


    //���lor�A���t�@�x�b�g�̃p�X���[�h�̃{�^�����N���b�N����邽�тɐ����p�X���[�h�Ɣ�r
    public void PassCheck()
    {
        if (IsClear() == true)
        {
            GimmickStatusManager.instance.StatusChanger(type);
            ClearEvent.Invoke();
            SoundManager.instance.PlaySound(SoundManager.instance.GimmickClearSound);
        }
    }


    //�����p�X���[�h�̐��l���Ή�����e�{�^���̌��݂̐��l(number)�ƈ�v���Ă��邩�m�F�@
    bool IsClear()
    {

        for (int i = 0; i < CorrectNumbers.Length; i++)
        {
            if (CorrectNumbers[i] != PassWordButtons[i].number)
            {
                return false;
            }
        }
        return true;

    }

    //�摜(�}�e���A��)�̃p�X���[�h�̃{�^�����N���b�N����邽�тɐ����p�X���[�h�Ɣ�r
    public void PassCheck_Image()
    {
        if (IsClear_Image() == true)
        {
            GimmickStatusManager.instance.StatusChanger(type);
            ClearEvent.Invoke();
            SoundManager.instance.PlaySound(SoundManager.instance.GimmickClearSound);
        }
    }

    //�����p�X���[�h�̐��l���Ή�����e�{�^���̌��݂̐��l(number)�ƈ�v���Ă��邩�m�F�@
    bool IsClear_Image()
    {

        for (int i = 0; i < CorrectNumbers.Length; i++)
        {
            if (CorrectNumbers[i] != ImageButtons[i].number)
            {
                return false;
            }
        }
        return true;

    }
}
