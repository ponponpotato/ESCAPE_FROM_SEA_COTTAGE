using UnityEngine;

//シーリングファンの回転クラス

public class RotateFun : MonoBehaviour
{

    public float rotateX = 0;
    public float rotateY = 0;
    public float rotateZ = 0;

    //電源スイッチがONならシーリングファンを回転させる
    void Update()
    {
        // X,Y,Z軸に対してそれぞれ、指定した角度ずつ回転させている。
        // deltaTimeをかけることで、フレームごとではなく、1秒ごとに回転するようにしている。
        if (GimmickStatusManager.instance.switchGimmick == false) return;
        gameObject.transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * Time.deltaTime);
    }
}
