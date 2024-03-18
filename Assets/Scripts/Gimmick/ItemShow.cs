using UnityEngine;

//��\���I�u�W�F�N�g�̕\���N���X

public class ItemShow : MonoBehaviour
{
    // �������A�C�e����I�����Ďg�p�������ʓ���̔�\���I�u�W�F�N�g��\��

    public GameObject InvisibleItem;
    public Item.Type type;

    //���ɃM�~�b�N�����܂Ȃ��p�^�[��
    public void InvisibleItemShow()
    {
        if (ItemBox.instance.CollectItemSelect(type) == true)
        {
            ShowFunction(true);
        }
    }

    //�g�C���̃h�A�̃h�A�m�u�\��
    public void InvisibleItemShow_DoorNobu()
    {
        if (ItemBox.instance.CollectItemSelect(type) == true)
        {
            ShowFunction(true, GimmickStatus.Type.DoorToiletGimmick);
        }
    }

    //�ނ�Ƃ̕\��
    public void InvisibleItemShow_SetRod()
    {
        if (ItemBox.instance.CollectItemSelect(type) == true)
        {
            ShowFunction(true, GimmickStatus.Type.SetRodGimmick);
        }
    }

    //�܂Ȕ̋��\��
    public void InvisibleItemShow_SetFish()
    {
        if (ItemBox.instance.CollectItemSelect(type) == true)
        {
            ShowFunction(true, GimmickStatus.Type.SetFishGimmick);
        }
    }

    //BBQ�O�������̐d�̑����؂�����̐d�\��
    public void ItemShow_Wood()
    {
        if (ItemBox.instance.CollectItemSelect(type) == true)
        {
            ShowFunction(true, GimmickStatus.Type.SetWoodGimmcik, true);
        }
    }

    //�A�C�e���Ȃ��Ŕ�\���I�u�W�F�N�g��\������p�^�[��
    public void ItemShow_NoItem()
    {
        ShowFunction(false, default, true);
    }

    //��\���I�u�W�F�N�g�̕\������ *�����͏ȗ��\
    void ShowFunction(bool UseItem = false, GimmickStatus.Type GimmickType = default, bool HideObject = false)
    {
        if (UseItem == true)
        {
            ItemBox.instance.ItemUsed();
        }
        if (GimmickType != default)
        {
            GimmickStatusManager.instance.StatusChanger(GimmickType);
        }
        if(HideObject == true)
        {
            gameObject.SetActive(false);
        }
        InvisibleItem.SetActive(true);
        SoundManager.instance.PlaySound(SoundManager.instance.PickUpSound);
    }

    //�����R���̃o�b�e���[�\��
    public void BatteryShow()
    {
        if (ItemBox.instance.CollectItemSelect(type) == true)
        {
            ItemBox.instance.ItemUsed();
            InvisibleItem.SetActive(true);
            foreach (Transform child in InvisibleItem.GetComponentInChildren<Transform>())
            {
                child.gameObject.SetActive(true);
            }
            GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.BatteryInputGimmick);
            SoundManager.instance.PlaySound(SoundManager.instance.PickUpSound);
        }
    }

}
