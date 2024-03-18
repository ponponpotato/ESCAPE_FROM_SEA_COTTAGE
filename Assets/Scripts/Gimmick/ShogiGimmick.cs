using UnityEngine;

//将棋のギミックのクラス

public class ShogiGimmick : MonoBehaviour
{
    [SerializeField] Material material = default;
    public Item.Type type = default;

    bool isNeedUpdate = true;
    private void Update()
    {
        //ロード時対策：すでにギミッククリアしている場合は、最終盤面にしておく
        if (isNeedUpdate == false) return;
        if (GimmickStatusManager.instance.shogiLastSceneGimmick == true)
        {
            Material[] materials = gameObject.GetComponent<Renderer>().materials;
            materials[1] = material;
            gameObject.GetComponent<Renderer>().materials = materials;
            isNeedUpdate = false;
        }
    }

    //追加棋譜を取得していたら、最終盤面を表示
    public void OnClickThis()
    {
        if (ItemBox.instance.CollectItemSelect(type) == false) return;
        ItemBox.instance.ItemUsed();
        Material[] materials = gameObject.GetComponent<Renderer>().materials;
        materials[1] = material;
        gameObject.GetComponent<Renderer>().materials = materials;
        GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.ShogiLastSceneGimmick);

    }
}
