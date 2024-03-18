using UnityEngine;

//�A�C�e���̐����N���X

public class ItemDataBase : MonoBehaviour
{
    public static ItemDataBase instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] ItemDataBaseEntity ItemDBEntity = default;

    //Item��type���琶������
    public Item Spawn(Item.Type type)
    {      
        foreach (Item itemdata in ItemDBEntity.items)
        {
            //�f�[�^�x�[�X����Type�̈�v������̂�T��
            if (itemdata.type == type)
            {
                return new Item(itemdata);
            }
        }
        return null;
    }

    //�Y�[�������A�C�e���̐���
    public GameObject CreateZoomItem(Item.Type type)
    {
        foreach (Item itemdata in ItemDBEntity.items)
        {
            if (itemdata.type == type)
            {
                return itemdata.zoomPrefab;
            }
        }
        return null;
    }
}
