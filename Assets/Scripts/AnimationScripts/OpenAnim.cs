using UnityEngine;
using UnityEngine.SceneManagement;

// �h�A������o���Ȃǂ��J���A�j���̃N���X�@���E�o�̍ۂ̃A�j��������

public class OpenAnim : MonoBehaviour
{
    [SerializeField]  Animator animator = default;
    public string OpenAnimName;
    public string CloseAnimName;
    public GimmickStatus.Type type = default;
    [SerializeField] GameObject ItemBoxCanvas = default;
    [SerializeField] GameObject CameraCanvas = default;
    [SerializeField] Animator ClearAnimator = default;

    // �N���b�N����ƁAOpen����
    public void Open()
    {

        if (type != GimmickStatus.Type.NoGimmick)
        {
            if (GimmickStatusManager.instance.StatusCheck(type) == false)
            {
                SoundManager.instance.PlaySound(SoundManager.instance.CancelSound);
                MessageShow.instance.ShowMessage("���b�N���������Ă���");
                return;
            }
        }

        // CloseAnimManager��Open�����A�j����animator/animname��ۑ��@������֘A��CloseAnimManager�ŊǗ�
        if (CloseAnimManeger.instance.IsOpen == false)
        {
            animator.Play(OpenAnimName);
            CloseAnimManeger.instance.IsOpen = true;
            CloseAnimManeger.instance.animator = this.animator;
            CloseAnimManeger.instance.animname = CloseAnimName;
            SoundManager.instance.PlaySound(SoundManager.instance.OpenSound);
        }
    }

    // �E�o�p�̃h�A�Ɋւ���A�j��
    public void Open_DoorEscape()
    {
        if (type != GimmickStatus.Type.NoGimmick)
        {
            if (GimmickStatusManager.instance.StatusCheck(type) == false)
            {
                SoundManager.instance.PlaySound(SoundManager.instance.CancelSound);
                MessageShow.instance.ShowMessage("���b�N���������Ă���");
                return;
            }
        }

        if (CloseAnimManeger.instance.IsOpen == false)
        {
            animator.Play(OpenAnimName);
            ItemBoxCanvas.SetActive(false);
            CameraCanvas.SetActive(false);
            SoundManager.instance.PlaySound(SoundManager.instance.OpenSound);
            Invoke("PlayClearEvent", 1.0f);
        }
    }

    // �E�o��̃C�x���g
    void PlayClearEvent()
    {
        ClearAnimator.Play("ClearEvent");
        SoundManager.instance.PlaySound(SoundManager.instance.WalkSound);
        Invoke("PlayClearSound", 3.0f);
    }

    // �E�o�����T�E���h
    void PlayClearSound()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.ClearEventSound);
        Invoke("ReturnMainMenu", 5.0f);
    }

    // ���C�����j���[�ɖ߂�
    void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }





}
