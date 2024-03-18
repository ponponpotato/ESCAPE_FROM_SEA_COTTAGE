using System.Collections.Generic;
using UnityEngine;

//解像度対応用のクラス

public class AspectSetter : MonoBehaviour
{

    [SerializeField] List<Camera> cameraList; 
    [SerializeField] List<GameObject> canvasList;
    Rect viewportRect;

    private void Awake()
    {
        adjustCamera();    
        //cameraAspectSet();
    }

    //目標のアスペクト比
    float targetAspect()
    {
        return (float)720 / 1280;
    }

    //CameraのFieldViewを解像度に合わせる
    void adjustCamera()
    {
        float currentAspectRatio = (float)Screen.width / Screen.height;
        float targetAspectRatio = targetAspect();

        //既存のカメラすべての視野角をアスペクト比に応じて変更
        foreach (Camera targetCamera in cameraList)
        {
            targetCamera.aspect = targetAspectRatio;

            //縦の視野角＝設定済みの視野角として取得
            //X方向の視野角はアスペクト比をもとに算出できる
            float DefaultFov = targetCamera.fieldOfView;

            if (currentAspectRatio < targetAspectRatio)
            {

                //Y方向の視野角からX方向の視野角を計算（カメラの視野角がY方向基準となっているため）
                targetCamera.fieldOfView = calculateHorizontalFOV(DefaultFov, currentAspectRatio / targetAspectRatio);

            }

        }

    }

    //x方向の視野角の計算
    float calculateHorizontalFOV(float fovY, float aspect)
    {
        float radY = fovY * Mathf.Deg2Rad;
        float radX = 2 * Mathf.Atan(Mathf.Tan(radY / 2) / aspect);
        float fovX = radX * Mathf.Rad2Deg;
        return fovX;
    }

    //これいらない
    //void cameraAspectSet()
    //{

    //    float screenAspect = Screen.width / (float)Screen.height; //画面のアスペクト比
    //    float targetAspect = this.targetAspect();                 //ターゲットのアスペクト比
    //    float mergeRate = targetAspect / screenAspect;　　　　　　 //目的アスペクト比にするための倍率

    //    Debug.Log(mergeRate);

    //    viewportRect = new Rect(0, 0, 1, 1); //viewport初期値でRectを作成

    //    if (mergeRate < 1)
    //    {
    //        viewportRect.width = mergeRate;                   //使用する横幅を変更
    //        viewportRect.x = 0.5f - viewportRect.width * 0.5f;//中央寄せ
    //    }
    //    else
    //    {
    //        viewportRect.height = 1 / mergeRate;               //使用する縦幅を変更
    //        viewportRect.y = 0.5f - viewportRect.height * 0.5f;//中央寄せ
    //    }

    //    foreach (Camera camera in cameraList)
    //    {
    //        camera.rect = viewportRect; //カメラのViewportに適用
    //    }

    //}



}
