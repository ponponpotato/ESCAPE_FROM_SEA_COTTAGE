using UnityEngine;

//スライムクリックしたらメッセージShow

public class SlimeClick : MonoBehaviour
{
    public void OnClickThis()
    {
        MessageShow.instance.ShowMessage("謎の生物。生きているようだ。");
    }
}
