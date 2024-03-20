using TMPro;
using UnityEngine;

//アイテムの取得クラス

public class PickUpObj : MonoBehaviour
{

    public Item.Type type = default;

    // アイテムの取得
    public void OnClick()
    {
        Debug.Log(type);
        Item item = ItemDataBase.instance.Spawn(type);
        ItemBox.instance.SetItem(item);
        gameObject.SetActive(false);
        SoundManager.instance.PlaySound(SoundManager.instance.PickUpSound);
    }

    //はめ込みアイテムの場合のアイテム取得ロジック
    public void OnClick_InputItem()
    {
        Debug.Log(type);
        Item item = ItemDataBase.instance.Spawn(type);
        ItemBox.instance.SetItem(item);
        gameObject.SetActive(false);

        //スロットのテキストメッシュプロを取得
        TextMeshProUGUI TextItem = ItemBox.instance.CountSlot.GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(ItemBox.instance.CountSlot);

        ItemBox.instance.ItemCount += 1;
        ItemBox.instance.InputItemTotalCount += 1;

        SoundManager.instance.PlaySound(SoundManager.instance.PickUpSound);

        switch (ItemBox.instance.ItemCount)
        {
            case 1:
                TextItem.text = "x1";
                return;
            case 2:
                TextItem.text = "x2";
                return;
            case 3:
                TextItem.text = "x3";
                return;
            case 4:
                TextItem.text = "x4";
                return;
        }

        

    }
}
