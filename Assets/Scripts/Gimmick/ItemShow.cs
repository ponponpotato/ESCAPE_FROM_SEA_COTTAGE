using UnityEngine;

//非表示オブジェクトの表示クラス

public class ItemShow : MonoBehaviour
{
    // 正しいアイテムを選択して使用した結果特定の非表示オブジェクトを表示

    public GameObject InvisibleItem;
    public Item.Type type;

    //特にギミックが絡まないパターン
    public void InvisibleItemShow()
    {
        if (ItemBox.instance.CollectItemSelect(type) == true)
        {
            ShowFunction(true);
        }
    }

    //トイレのドアのドアノブ表示
    public void InvisibleItemShow_DoorNobu()
    {
        if (ItemBox.instance.CollectItemSelect(type) == true)
        {
            ShowFunction(true, GimmickStatus.Type.DoorToiletGimmick);
        }
    }

    //釣り竿の表示
    public void InvisibleItemShow_SetRod()
    {
        if (ItemBox.instance.CollectItemSelect(type) == true)
        {
            ShowFunction(true, GimmickStatus.Type.SetRodGimmick);
        }
    }

    //まな板の魚表示
    public void InvisibleItemShow_SetFish()
    {
        if (ItemBox.instance.CollectItemSelect(type) == true)
        {
            ShowFunction(true, GimmickStatus.Type.SetFishGimmick);
        }
    }

    //BBQグリル下の薪の束線切った後の薪表示
    public void ItemShow_Wood()
    {
        if (ItemBox.instance.CollectItemSelect(type) == true)
        {
            ShowFunction(true, GimmickStatus.Type.SetWoodGimmcik, true);
        }
    }

    //アイテムなしで非表示オブジェクトを表示するパターン
    public void ItemShow_NoItem()
    {
        ShowFunction(false, default, true);
    }

    //非表示オブジェクトの表示処理 *引数は省略可能
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

    //リモコンのバッテリー表示
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
