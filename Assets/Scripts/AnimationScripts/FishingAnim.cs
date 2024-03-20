using UnityEngine;

// �ނ�̃A�j��

public class FishingAnim : MonoBehaviour
{

    [SerializeField] GameObject ShowObj_rod;
    [SerializeField] GameObject ShowObj_fish;
    [SerializeField] Animator animator;

    //�����ނ���ԁi�X�e�[�L���M�ɂ̂���M�~�b�N�N���A�j�ɂȂ��Ă�����A�ނ�Ƃ��h���A�j���[�V��������x�����Đ�
    bool isAnimActive = false;
    private void Update()
    {
        if (GimmickStatusManager.instance.StatusCheck(GimmickStatus.Type.SetFood_MeetGimmick) == true && isAnimActive == false)
        {
            animator.Play("Fishing_Ready");
            isAnimActive = true;
        }
    }

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
        GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.FishingGimmick);
    }

}
