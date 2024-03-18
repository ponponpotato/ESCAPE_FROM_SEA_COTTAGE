using UnityEngine;

//マテリアル画像の変更クラス

public class ImageChanger : MonoBehaviour
{
    [SerializeField] Material[] Materials = default;
    [SerializeField] GimmickStatus.Type type;

    //PassWordCheckクラスで各パスワードボタンのnumberを正解のパスワードと照らし合わせる
    public int number = 0;

    private void Start()
    {
        number = 0;
    }

    //クリックするとマテリアルのnumberを＋１して変更
    public void OnClickThis()
    {
        if (GimmickStatusManager.instance.StatusCheck(type) == true) return;

        number++;
        if (number > Materials.Length - 1)//配列の領域超えたら、0にリセット
        {
            number = 0;
        }
        gameObject.GetComponent<Renderer>().material = Materials[number];

    }

}