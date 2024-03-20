using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;

//アイテムの保管スロットのクラス

public class ItemBox : MonoBehaviour
{

    //ItemBoxですべてのSlotを把握
    [SerializeField] Slot[] slots = default;

    public static ItemBox instance;

    //選択アイテムのスロット保管変数
    Slot SelectedSlot;

    //はめ込みアイテムのカウント変数と使用スロット
    public int ItemCount = 0;
    public int InputItemTotalCount = 0;
    public Slot CountSlot = default;

    private void Awake()
    {
        instance = this;
    }

    //クリックしたら、Itemを受け取る
    public void SetItem(Item item)
    {
        //左ずめでアイテムを格納
        foreach (Slot slot in slots)
        {
            if (item.type == Item.Type.InputItem && ItemCount > 0)
            {
                CountSlot.SetImage(item);
                break;
            }
            else if (item.type == Item.Type.InputItem)
            {
                if (slot.IsEmpty() == true)
                {
                    slot.SetImage(item);
                    CountSlot = slot; //はめ込みアイテムが格納されているスロットを保持
                    break;
                }
            }

            if (slot.IsEmpty() == true)
            {
                slot.SetImage(item);
                break;
            }

        }

    }

    //スロットをクリックした時
    public void OnSlotClick(int position)
    {

        if (slots[position].IsEmpty() == true) return;

        //imageはクリックしたとき、すべて黒背景解除してから黒背景を表示
        foreach(Slot slot in slots)
        {
            slot.OffSelect();
        }
        slots[position].OnSelect();

        //選択中のアイテムスロットを取得
        SelectedSlot = slots[position];
    }

    //正しいアイテムを選択しているかどうかを判別
    public bool CollectItemSelect(Item.Type UseItemType)
    {
        if (SelectedSlot == null) return false;

        if (SelectedSlot.GetItem().type == UseItemType)
        {
            if (SelectedSlot.GetItem().type == Item.Type.InputItem)
            {
                ItemCount = 0;
                CountSlot.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "";
            }
            return true;
        }
        return false;
    }

    //スロットのアイテム保存
    public async UniTask<StringBuilder> saveSlotItems()
    {
        await UniTask.SwitchToThreadPool();

        StringBuilder stringBuilder = new StringBuilder();

        int IDCount = 0;
        foreach(Slot slot in slots)
        {
            if(slot.IsEmpty() == false)
            {
                string ItemName = slot.GetItem().type.ToString();

                stringBuilder.Append("SlotItem" + IDCount + "%" + ItemName + "\n");

                if (slot.GetItem().type == Item.Type.InputItem)
                {
                    stringBuilder.Append("InputItemCount"  + "%" + ItemCount + "\n");
                }
                IDCount++;
            }

        }

        stringBuilder.Append("InputItemTotalCount" + "%" + InputItemTotalCount + "\n");

        stringBuilder.Append("SlotItemCount" + "%" + IDCount + "\n");

        await UniTask.SwitchToMainThread();

        return stringBuilder;
    }

    //スロットに保存したアイテムをロード
    public async UniTask LoadSlotItems(Dictionary<string,string> loadDataDictionary)
    {

        int Count = 0;
        int IDCount = int.Parse(loadDataDictionary.FirstOrDefault(item => item.Key == "SlotItemCount").Value);
        while (Count < IDCount)
        {
            string SaveItemName = "";
            try
            {
                SaveItemName = loadDataDictionary.FirstOrDefault(item => item.Key == "SlotItem" + Count).Value;
            }
            catch
            {
                continue;
            }
                

            foreach (Item.Type type in Item.Type.GetValues(typeof(Item.Type)))
            {
                string ItemName = Enum.GetName(typeof(Item.Type), type);

                if(SaveItemName == ItemName)
                {
                    Item item = ItemDataBase.instance.Spawn(type);
                    slots[Count].SetImage(item);
                    if (type == Item.Type.InputItem) SetInputItemCount(slots[Count],loadDataDictionary);
                }

            }

            Count++;

        }

        try
        {
            InputItemTotalCount = int.Parse(loadDataDictionary.FirstOrDefault(item => item.Key == "InputItemTotalCount").Value);
        }
        catch
        {
            InputItemTotalCount = 0;
        }

        await UniTask.SwitchToMainThread();

    }

    //InputItem(はめ込みアイテム)のみ個数を表示する
    void SetInputItemCount(Slot TargetSlot,Dictionary<string,string> loadDataDictionary)
    {
        CountSlot = TargetSlot;
        TextMeshProUGUI TextItem = CountSlot.GetComponentInChildren<TextMeshProUGUI>();
        ItemCount = int.Parse(loadDataDictionary.FirstOrDefault(item => item.Key == "InputItemCount").Value);
        TextItem.text = "x" + ItemCount;

    }

    //アイテムの使用
    public void ItemUsed()
    {
        SelectedSlot.RemoveImage();
        SelectedSlot = null;
    }

    //選択中のスロットのアイテム取得
    public Item GetSelectedItem()
    {
        if (SelectedSlot == null)
        {
            return null;
        }
        return SelectedSlot.GetItem();
    }
}
