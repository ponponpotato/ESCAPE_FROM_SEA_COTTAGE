using UnityEngine;
using UnityEngine.SceneManagement;

// ドアや引き出しなどを開くアニメのクラス　＊脱出の際のアニメもあり

public class OpenAnim : MonoBehaviour
{
    [SerializeField]  Animator animator = default;
    public string OpenAnimName;
    public string CloseAnimName;
    public GimmickStatus.Type type = default;
    [SerializeField] GameObject ItemBoxCanvas = default;
    [SerializeField] GameObject CameraCanvas = default;
    [SerializeField] Animator ClearAnimator = default;

    // クリックすると、Openする
    public void Open()
    {

        if (type != GimmickStatus.Type.NoGimmick)
        {
            if (GimmickStatusManager.instance.StatusCheck(type) == false)
            {
                SoundManager.instance.PlaySound(SoundManager.instance.CancelSound);
                MessageShow.instance.ShowMessage("ロックがかかっている");
                return;
            }
        }

        // CloseAnimManagerにOpenしたアニメのanimator/animnameを保存　＊閉じる関連はCloseAnimManagerで管理
        if (CloseAnimManeger.instance.IsOpen == false)
        {
            animator.Play(OpenAnimName);
            CloseAnimManeger.instance.IsOpen = true;
            CloseAnimManeger.instance.animator = this.animator;
            CloseAnimManeger.instance.animname = CloseAnimName;
            SoundManager.instance.PlaySound(SoundManager.instance.OpenSound);
        }
    }

    // 脱出用のドアに関するアニメ
    public void Open_DoorEscape()
    {
        if (type != GimmickStatus.Type.NoGimmick)
        {
            if (GimmickStatusManager.instance.StatusCheck(type) == false)
            {
                SoundManager.instance.PlaySound(SoundManager.instance.CancelSound);
                MessageShow.instance.ShowMessage("ロックがかかっている");
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

    // 脱出後のイベント
    void PlayClearEvent()
    {
        ClearAnimator.Play("ClearEvent");
        SoundManager.instance.PlaySound(SoundManager.instance.WalkSound);
        Invoke("PlayClearSound", 3.0f);
    }

    // 脱出成功サウンド
    void PlayClearSound()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.ClearEventSound);
        Invoke("ReturnMainMenu", 5.0f);
    }

    // メインメニューに戻る
    void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }





}
