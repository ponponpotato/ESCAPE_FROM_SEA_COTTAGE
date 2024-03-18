using UnityEngine;

//�A�C�e���̍��W�ύX�N���X

public class ItemTransForm : MonoBehaviour
{
    public Vector3 NewlocalPos;
    public Vector3 rotation;
    Transform myTransform;

    private void Start()
    {
        myTransform = this.gameObject.GetComponent<Transform>();
    }

    //���[�J�����W�ŕύX����ꍇ
    public void OnClickThis_Local()
    {
        myTransform.localPosition = NewlocalPos;   
        myTransform.localRotation = Quaternion.Euler(rotation);
    }

    //���[���h���W�ŕύX����ꍇ
    public void OnClickThis_World()
    {
        myTransform.position = NewlocalPos;
        myTransform.rotation = Quaternion.Euler(rotation);
    }
}
