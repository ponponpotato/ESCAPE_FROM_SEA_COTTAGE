using UnityEngine;

//�e���r�̃��b�N�̈����o���̃A�j���N���X > OpenAnim�Ɉڍs

public class DrawerOpen : MonoBehaviour
{

    [SerializeField] Animator animator = default;

    public void PlayTVDrawerAnim()
    {
        animator.Play("TVDrawerOpen");
    }
}
