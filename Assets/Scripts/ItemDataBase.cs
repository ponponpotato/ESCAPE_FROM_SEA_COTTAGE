using UnityEngine;

//アイテムの生成クラス

public class ItemDataBase : MonoBehaviour
{
    public static ItemDataBase instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] ItemDataBaseEntity ItemDBEntity = default;

    //Itemをtypeから生成する
    public Item Spawn(Item.Type type)
    {      
        foreach (Item itemdata in ItemDBEntity.items)
        {
            //データベースからTypeの一致するものを探す
            if (itemdata.type == type)
            {
                return new Item(itemdata);
            }
        }
        return null;
    }

    //ズームしたアイテムの生成
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
