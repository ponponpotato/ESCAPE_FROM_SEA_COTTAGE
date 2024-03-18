using UnityEngine;

//テレビのラックの引き出しのアニメクラス > OpenAnimに移行

public class DrawerOpen : MonoBehaviour
{

    [SerializeField] Animator animator = default;

    public void PlayTVDrawerAnim()
    {
        animator.Play("TVDrawerOpen");
    }
}
