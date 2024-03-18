using UnityEngine;

// ��������o���ȂǊJ�I�u�W�F�N�g����邽�߂̃N���X
// �I�u�W�F�N�g�̊J���s��ꂽ�ۂ́A���̃I�u�W�F�N�g�̕��邽�߂̃A�j���[�^�[/�A�j�����������ɕۑ����Ă���

public class CloseAnimManeger : MonoBehaviour
{
    public Animator animator = null;
    public string animname = "";
    public bool IsOpen = default;

    public static CloseAnimManeger instance;

    private void Awake()
    {
        instance = this;
    }

    // ����A�j��
    public void CloseAnim()
    {
        if (IsOpen == true)
        {
            animator.Play(animname);
            animator = null;
            animname = "";
            IsOpen = false;
        }
        
    }

    public bool IsOpenCheck()
    {
        return IsOpen;
    }


}
