using TMPro;
using UnityEngine;

//アイテム拡大パネル実装

public class ZoomPanel : MonoBehaviour
{
    // zoomPanelの表示
    //メインカメラ以外でも見れるようにする

    [SerializeField] GameObject zoomPanel;
    [SerializeField] Transform ZoomObjParent;
    [SerializeField] TextMeshProUGUI UIText;
    Canvas canvas;
    GameObject ZoomedItem;
    Transform RectTransform;
    public static ZoomPanel instance;
    public Item SelectedItem;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        canvas = GetComponent<Canvas>();
        RectTransform = ZoomObjParent.GetComponent<RectTransform>();
        UIText.text = "";
        HideZoomPanel();
    }

    void ShowItem()
    {
        //選択中のアイテムを表示する
        //表示する=データベースから生成する
        //prefabを生成するときはInstantiateであらかじめ生成してから使用する。変数に入れるときにすでにInstantiateしておかないと意味がない
        if(ZoomedItem != null)
        {
            Destroy(ZoomedItem);
        }
        SelectedItem = ItemBox.instance.GetSelectedItem();
        ZoomedItem = Instantiate(ItemDataBase.instance.CreateZoomItem(SelectedItem.type));
        ZoomedItem.transform.SetParent(ZoomObjParent,false); //falseにしてローカル座標の倍率にする
        RectTransform.localRotation = Quaternion.Euler(0, 0, 0);
        TextSetter(SelectedItem);
    }

    //キャンバスのカメラを現在使用中のカメラに切り替え
    public void SetRenderCamera(Camera camera)
    {
        canvas.worldCamera = camera;
    }

    //アイテム拡大パネル表示
    public void OnClickZoom()
    {
        if (ItemBox.instance.GetSelectedItem() == null) return;
        zoomPanel.SetActive(true);
        ShowItem();
    }

    //アイテム拡大パネル非表示
    public void HideZoomPanel()
    {
        zoomPanel.SetActive(false);
    }

    //アイテムの名前テキストの設定
    void TextSetter(Item item)
    {
        UIText.text = item.ItemName;
    }
}
