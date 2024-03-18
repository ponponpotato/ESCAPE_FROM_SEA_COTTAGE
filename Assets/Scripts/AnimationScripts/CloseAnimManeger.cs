using UnityEngine;

// 扉や引き出しなど開閉オブジェクトを閉じるためのクラス
// オブジェクトの開閉が行われた際は、そのオブジェクトの閉じるためのアニメーター/アニメ名をここに保存しておく

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

    // 閉じるアニメ
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
