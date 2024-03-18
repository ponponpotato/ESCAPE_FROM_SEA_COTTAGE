using UnityEngine;

//ドアのアンロックギミックのクラス

public class DoorUnLock : MonoBehaviour
{
    public Item.Type type = default;
    public GimmickStatus.Type GimmickType = default;

    public void KeyGimmick()
    {
        if (ItemBox.instance.CollectItemSelect(type) == true)//緑or赤のカギ選択してなかったらreturn
        {
            ItemBox.instance.ItemUsed();
            GimmickStatusManager.instance.StatusChanger(GimmickType);
            SoundManager.instance.PlaySound(SoundManager.instance.UnlockSound);
        }
    }

}
