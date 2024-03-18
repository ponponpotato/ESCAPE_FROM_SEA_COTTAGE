using UnityEngine;

// �g�C���̃h�A�̃A�j��

public class DoorToiletAnim : MonoBehaviour
{
    [SerializeField] Animator animator = default;

    public void OnClickObj()
    {

        if (GimmickStatusManager.instance.doorToiletGimmick == false) // �h�A�m�u�t���ĂȂ�������return
        {
            MessageShow.instance.ShowMessage("�h�A�m�u�������ĊJ���Ȃ�...");
            return;
        }
        if (CloseAnimManeger.instance.IsOpen == false) // �h�A�J���ĂȂ�������Open ����p�̃A�j���[�^�[/�A�j������CloseAnimManager�ɕۑ�
        {
            animator.Play("DoorToiletOpen");
            CloseAnimManeger.instance.IsOpen = true;
            CloseAnimManeger.instance.animator = animator;
            CloseAnimManeger.instance.animname = "DoorToiletClose";
        }
        else
        {
            animator.Play("DoorToiletClose");
            CloseAnimManeger.instance.IsOpen = false;
        }

    }

}
