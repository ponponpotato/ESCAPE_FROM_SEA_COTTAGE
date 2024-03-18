using UnityEngine;

//アイテムの座標変更クラス

public class ItemTransForm : MonoBehaviour
{
    public Vector3 NewlocalPos;
    public Vector3 rotation;
    Transform myTransform;

    private void Start()
    {
        myTransform = this.gameObject.GetComponent<Transform>();
    }

    //ローカル座標で変更する場合
    public void OnClickThis_Local()
    {
        myTransform.localPosition = NewlocalPos;   
        myTransform.localRotation = Quaternion.Euler(rotation);
    }

    //ワールド座標で変更する場合
    public void OnClickThis_World()
    {
        myTransform.position = NewlocalPos;
        myTransform.rotation = Quaternion.Euler(rotation);
    }
}
