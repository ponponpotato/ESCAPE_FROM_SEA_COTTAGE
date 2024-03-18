using UnityEngine;

//マテリアルの変更クラス

public class MaterialChange : MonoBehaviour
{
    [SerializeField] Material NewMaterial = default;
    public Item.Type type = default;


    //アイテムを使用して、マテリアルを変更 *ここではフォトギミックのみ
    public void OnClickThis()
    {
        if (ItemBox.instance.CollectItemSelect(type) == true)
        {
            ItemBox.instance.ItemUsed();
            gameObject.GetComponent<Renderer>().material = NewMaterial;
            GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.PhotoSetGimmick);
        }
    }
}
