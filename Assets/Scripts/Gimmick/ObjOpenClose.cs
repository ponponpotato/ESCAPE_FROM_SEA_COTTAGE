using UnityEngine;

//�I�u�W�F�N�g�̊J�N���X

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
            MessageShow.instance.ShowMessage("�d�r�͂��łɓ����Ă���");
        }
    }

}
