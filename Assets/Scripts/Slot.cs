using UnityEngine;
using UnityEngine.UI;

//スロットのクラス

public class Slot : MonoBehaviour
{
    [SerializeField] GameObject BackPanel = default;
    [SerializeField] Image image = default ;
    Item item = null;

    private void Start()
    {
        BackPanel.SetActive(false);
    }

    //画像のセット
    public void SetImage(Item item)
    {
        this.item = item;
        image.sprite = item.sprite;
    }

    //画像削除
    public void RemoveImage()
    {
        item = null;
        image.sprite = null;
        OffSelect();
    }

    //Slotに確保されているアイテムを返す
    public Item GetItem() 
    {
        return item;
    }

    //スロットが空かどうかの判別
    public bool IsEmpty()
    {
        if (item == null)
        {
            return true;
        }
        return false;
    }

    //スロットの黒背景パネル表示
    public void OnSelect()
    {
        BackPanel.SetActive(true);
    }

    //スロットの黒背景パネル非表示
    public void OffSelect()
    {
        BackPanel.SetActive(false);
    }

}
