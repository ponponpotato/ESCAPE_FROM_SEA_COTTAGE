using UnityEngine;

//オブジェクトの開閉クラス

public class ObjOpenClose : MonoBehaviour
{
    public GameObject CloseObj;
    public GameObject OpenObj;

    //public static ObjOpenClose instance;

    public void objOpenClose()
    {
        CloseObj.SetActive(false);
        OpenObj.SetActive(true);
    }

    public void objOpenClose_Remocon()
    {
        if (GimmickStatusManager.instance.batteryInputGimmick == false)
        {
            CloseObj.SetActive(false);
            OpenObj.SetActive(true);
        }
        else
        {
            MessageShow.instance.ShowMessage("電池はすでに入っている");
        }
    }

}
