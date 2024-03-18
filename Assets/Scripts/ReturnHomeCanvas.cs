using UnityEngine;

//ホーム(メインメニュー)に帰る・もしくはHintを表示するキャンバスの挙動管理

public class ReturnHomeCanvas : MonoBehaviour
{

    [SerializeField] GameObject ParentPanel = default;
    [SerializeField] GameObject HintPanel = default;
    //bool IsShow = false;

    //親パネルの表示
    public void ShowParentPanel()
    {
        ParentPanel.SetActive(true);
        //IsShow = true;
    }

    //親パネルの非表示
    public void HideParentPanel()
    {
        ParentPanel.SetActive(false);
        //IsShow = false;
    }

    //ヒントパネルの非表示
    public void HideHintPanel()
    {
        HintPanel.SetActive(false);
    }
}
