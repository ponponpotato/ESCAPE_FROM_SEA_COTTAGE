using UnityEngine;

// �d�ɉt�̔R����h�z����A�j��(�d��BBQ�O�����ɃZ�b�g����̂������ōs��)

public class WoodOilGimmick : MonoBehaviour
{
    [SerializeField] GameObject WoodObj_before = default;
    [SerializeField] GameObject WoodObj_after = default;
    [SerializeField] Animator animator = default;


    public void OnClick()
    {
        Item item = ItemBox.instance.GetSelectedItem();

        if (item == null) return;

        switch (item.type)
        {
            //�d��BBQ�O�����ɃZ�b�g
            case Item.Type.Wood:
                WoodObj_before.SetActive(true);
                ItemBox.instance.ItemUsed();
                GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.SetWoodGimmcik);
                return;

            //�d�ɉt�̔R����h�z
            case Item.Type.Oil:
                if (GimmickStatusManager.instance.setWoodGimmick  == true)
                {
                    ItemBox.instance.ItemUsed();
                    WoodObj_before.SetActive(false);
                    animator.Play("OilApply");
                    Invoke("PlaySound", 0.5f);
                    Invoke("PlaySound", 1.5f);
                    Invoke("Wood_AfterShow", 2.0f);
                }
                return;
        }
    }

    // �t�̔R���h�z��
    void PlaySound()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.OilApplySound);
    }

    // �h�z��̐d(�G�ꂽ������)�\���ƃM�~�b�N�̐i���X�V
    void Wood_AfterShow()
    {
        WoodObj_after.SetActive(true);
        GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.ApplyOilGimmick);
    }
}
