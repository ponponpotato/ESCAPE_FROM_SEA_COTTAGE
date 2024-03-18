using UnityEngine;

// �d�C�X�C�b�`�{�b�N�X�֘A�̃A�j��

public class SwitchBoxGimmick : MonoBehaviour
{
    // RemoveBoltAnim�֘A
    [SerializeField] GameObject animatorObj = default;
    [SerializeField] Item.Type type;

    // Switch�֘A
    [SerializeField] Material material;
    [SerializeField] GameObject SwitchObj = default;
    [SerializeField] GameObject InvisibleItem = default;
    [SerializeField] GameObject HideItem = default;
    bool IsSwitchOn = false;

    private void Update()
    {
        //���[�h���΍�F���łɂɃX�C�b�`�I���M�~�b�N���������Ă����ꍇ�͈ȉ�������
        if (IsSwitchOn == true) return;
        if (GimmickStatusManager.instance.switchGimmick == true)
        {
            SwitchObj.GetComponent<Renderer>().material = material;
            IsSwitchOn = true;
        }
    }

    // �{�b�N�X�̃{���g�����A�j��
    public void PlayRemoveBoltAnim()
    {
        if (ItemBox.instance.CollectItemSelect(type) == false) return;

        ItemBox.instance.ItemUsed();
        Animator animator = animatorObj.GetComponentInChildren<Animator>();
        animator.Play("RemoveBolt");
        Invoke("StatusUpdate", 2.0f);
        
    }

    // �M�~�b�N�̐i���X�V
    void StatusUpdate()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.UnlockSound);
        GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.RemoveBoltGimmick);
        animatorObj.SetActive(false);
    }


    // �d�C�̃X�C�b�`ON�̃A�j�� > ON�̏ꍇ�̓V�[�����O�t�@������]���A�C�e�����h���b�v(��\������A�N�e�B�u��)����
    public void SwitchOn()
    {
        if (IsSwitchOn == true) return;
        if (GimmickStatusManager.instance.removeBoltGimmick == false) return;

        IsSwitchOn = true;
        SwitchObj.GetComponent<Renderer>().material = material;
        GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.SwitchGimmick);
        SoundManager.instance.PlaySound(SoundManager.instance.SwitchOnSound);
        Invoke("ShowBall", 1.0f);
  
    }

    // �A�C�e���̕\��(�����ʃs���N)
    void ShowBall()
    {
        HideItem.SetActive(false);
        InvisibleItem.SetActive(true);
        SoundManager.instance.PlaySound(SoundManager.instance.DropBallSound);
    }
}
