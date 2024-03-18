using UnityEngine;

//テレビのギミッククラス

public class TVGimmick : MonoBehaviour
{
    [SerializeField] Material[] NewMaterials = default;
    [SerializeField] GameObject TVLamp = default;
    [SerializeField] Material TVLampMaterial = default;
    public Item.Type type = default;
    public int CurrentIndex = 0;

    private void Start()
    {
        CurrentIndex = 0;
    }

    //電池が入っている状態のリモコンでテレビをON、以降はテレビをクリックするとチャンネルが切り替わる
    public void OnClickThis()
    {
        //リモコンにバッテリー入っているかの確認
        if (ItemBox.instance.CollectItemSelect(type) == true)
        {
            if (GimmickStatusManager.instance.batteryInputGimmick == false)
            {
                MessageShow.instance.ShowMessage("電池が入っていないようだ");
                return;
            }
            ItemBox.instance.ItemUsed();
            GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.TvSwitchOnGimmick);
        }
        else
        {
            if (GimmickStatusManager.instance.batteryInputGimmick == false) return;
        }

        //テレビの電源をON（ロード時にテレビの電源ONのギミックが完了している時ようにここで進捗状況確認)
        if (GimmickStatusManager.instance.tvSwitchOnGimmick == false) return;
        TVLamp.GetComponent<Renderer>().material = TVLampMaterial;

        //クリックされた回数に応じてチャンネル切り替え
        if (CurrentIndex > 3) CurrentIndex = 0;
        gameObject.GetComponent<Renderer>().material = NewMaterials[CurrentIndex];
        CurrentIndex++;
    }

}
