using UnityEngine;

//アイテムの回転クラス

public class ItemRotation : MonoBehaviour
{
    //回転軸(親オブジェクト)のTransform
    [SerializeField] Transform ParentAxis;

    //回転速度の調整用
    float k = 1000f;

    //タッチでアイテムを回転
    private Vector2 touchStartPos;

    // タッチ感度
    float touchSensitivity = 0.01f;


    void Update()
    {
        if (ZoomPanel.instance.SelectedItem.type != Item.Type.Remocon) return;

        if (Input.touchCount > 0)
        {
            //最初のタッチを取得
            Touch touch = Input.GetTouch(0);

            
            if (touch.phase == TouchPhase.Began)//タッチのフェーズが始まったとき
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)//タッチが動いている時
            {
                float touchDeltaX = touch.position.x - touchStartPos.x;
                float x = -touchDeltaX * touchSensitivity * Time.deltaTime * k;

                transform.RotateAround(transform.position, Quaternion.Euler(ParentAxis.rotation.eulerAngles) * Vector3.up, x);
            }

        }

    }

}
