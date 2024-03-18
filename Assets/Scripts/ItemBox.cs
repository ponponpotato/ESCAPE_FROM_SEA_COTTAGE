using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;

//�A�C�e���̕ۊǃX���b�g�̃N���X

public class ItemBox : MonoBehaviour
{

    //ItemBox�ł��ׂĂ�Slot��c��
    [SerializeField] Slot[] slots = default;

    public static ItemBox instance;

    //�I���A�C�e���̃X���b�g�ۊǕϐ�
    Slot SelectedSlot;

    //�͂ߍ��݃A�C�e���̃J�E���g�ϐ��Ǝg�p�X���b�g
    public int ItemCount = 0;
    public int TotalItemCount = 0;
    public Slot CountSlot = default;

    private void Awake()
    {
        instance = this;
    }

    //�N���b�N������AItem���󂯎��
    public void SetItem(Item item)
    {
        //�����߂ŃA�C�e�����i�[
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
                    CountSlot = slot; //�͂ߍ��݃A�C�e�����i�[����Ă���X���b�g��ێ�
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

    //�X���b�g���N���b�N������
    public void OnSlotClick(int position)
    {

        if (slots[position].IsEmpty() == true) return;

        //image�̓N���b�N�����Ƃ��A���ׂč��w�i�������Ă��獕�w�i��\��
        foreach(Slot slot in slots)
        {
            slot.OffSelect();
        }
        slots[position].OnSelect();

        //�I�𒆂̃A�C�e���X���b�g���擾
        SelectedSlot = slots[position];
    }

    //�������A�C�e����I�����Ă��邩�ǂ����𔻕�
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

    //�X���b�g�̃A�C�e���ۑ�
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
                //PlayerPrefs.SetString("SlotItem_" + IDCount, ItemName);
                if (slot.GetItem().type == Item.Type.InputItem)
                {
                    stringBuilder.Append("InputItemCount"  + "%" + ItemCount + "\n");
                    stringBuilder.Append("InputItemTotalCount"  + "%" + TotalItemCount + "\n");
                    //PlayerPrefs.SetInt("InputItemCount_", ItemCount);
                    //PlayerPrefs.SetInt("InputItemTotalCount_", TotalItemCount);
                    //Debug.Log(TotalItemCount);
                }
                IDCount++;
                //Debug.Log(ItemName + "���Z�[�u����");
            }

        }

        stringBuilder.Append("SlotItemCount" + "%" + IDCount + "\n");
        //PlayerPrefs.SetInt("SlotItemCount", IDCount);

        await UniTask.SwitchToMainThread();

        return stringBuilder;
    }

    //�X���b�g�ɕۑ������A�C�e�������[�h
    public async UniTask LoadSlotItems(Dictionary<string,string> loadDataDictionary)
    {

        //await UniTask.SwitchToThreadPool();
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
            TotalItemCount = int.Parse(loadDataDictionary.FirstOrDefault(item => item.Key == "InputItemTotalCount").Value);
        }
        catch
        {
            TotalItemCount = 0;
        }

        //await UniTask.SwitchToMainThread();

    }

    //InputItem(�͂ߍ��݃A�C�e��)�̂݌���\������
    void SetInputItemCount(Slot TargetSlot,Dictionary<string,string> loadDataDictionary)
    {
        CountSlot = TargetSlot;
        TextMeshProUGUI TextItem = CountSlot.GetComponentInChildren<TextMeshProUGUI>();
        ItemCount = int.Parse(loadDataDictionary.FirstOrDefault(item => item.Key == "InputItemCount").Value);
        TextItem.text = "x" + ItemCount;

    }

    //�A�C�e���̎g�p
    public void ItemUsed()
    {
        SelectedSlot.RemoveImage();
        SelectedSlot = null;
    }

    //�I�𒆂̃X���b�g�̃A�C�e���擾
    public Item GetSelectedItem()
    {
        if (SelectedSlot == null)
        {
            return null;
        }
        return SelectedSlot.GetItem();
    }
}
