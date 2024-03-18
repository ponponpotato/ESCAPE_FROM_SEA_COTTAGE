using UnityEngine;

// �ނ�̃A�j��

public class FishingAnim : MonoBehaviour
{

    [SerializeField] GameObject ShowObj_rod;
    [SerializeField] GameObject ShowObj_fish;
    [SerializeField] Animator animator;

    // �X�e�[�L�������`�����}�b�g�ɃZ�[�u����M�~�b�N���������Ă���ꍇ�Ɏ��s�\
    public void PlayFishingAnim()
    {
        if (GimmickStatusManager.instance.setFood_MeetGimmick == true)
        {
            animator.Play("Fishing");
            SoundManager.instance.PlaySound(SoundManager.instance.FishingSound);
            Invoke("ShowItem", 0.75f);
        }
    }

    // �ނ�����́A�Q�������ނ�Ƃƃo�P�c�ɓ��������\��
    void ShowItem()
    {
        gameObject.SetActive(false);
        ShowObj_rod.SetActive(true);
        ShowObj_fish.SetActive(true);
    }

}
