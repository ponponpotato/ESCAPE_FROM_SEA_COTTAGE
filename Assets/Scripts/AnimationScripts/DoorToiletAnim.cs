using UnityEngine;

// トイレのドアのアニメ

public class DoorToiletAnim : MonoBehaviour
{
    [SerializeField] Animator animator = default;

    public void OnClickObj()
    {

        if (GimmickStatusManager.instance.doorToiletGimmick == false) // ドアノブ付けてなかったらreturn
        {
            MessageShow.instance.ShowMessage("ドアノブが無くて開けない...");
            return;
        }
        if (CloseAnimManeger.instance.IsOpen == false) // ドア開いてなかったらOpen 閉じる用のアニメーター/アニメ名をCloseAnimManagerに保存
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
