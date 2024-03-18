using UnityEngine;

//�h�A�̃A�����b�N�M�~�b�N�̃N���X

public class DoorUnLock : MonoBehaviour
{
    public Item.Type type = default;
    public GimmickStatus.Type GimmickType = default;

    public void KeyGimmick()
    {
        if (ItemBox.instance.CollectItemSelect(type) == true)//��or�Ԃ̃J�M�I�����ĂȂ�������return
        {
            ItemBox.instance.ItemUsed();
            GimmickStatusManager.instance.StatusChanger(GimmickType);
            SoundManager.instance.PlaySound(SoundManager.instance.UnlockSound);
        }
    }

}
