using UnityEngine;

// zoom先のカメラの設定をするクラス　＊CameraMnagerクラスで細かい処理は行う

public class ZoomCameraSetter : MonoBehaviour
{
    // クリックされたらズーム用のカメラに切り替える
    [SerializeField] Camera zoomCamera = default;

    //1階：1段階目のズーム
    public void OnClickObj_ZoomType0()
    {
        ZoomPanel.instance.SetRenderCamera(zoomCamera);
        zoomCamera.gameObject.SetActive(true);
        CameraManager.instance.SetZoomCamera_ZoomType0(zoomCamera);
        CloseAnimManeger.instance.CloseAnim();
    }

    //1階：2段階目のズーム(BackButtonあり)
    public void OnClickObj_ZoomType1()
    {
        ZoomPanel.instance.SetRenderCamera(zoomCamera);
        zoomCamera.gameObject.SetActive(true);
        CameraManager.instance.SetZoomCamera_ZoomType1(zoomCamera);
        CloseAnimManeger.instance.CloseAnim();
    }

    //1階：2段階目のズーム(BackButtonなし)＊ベランダのカメラからさらにズームするパターン
    public void OnClickObj_ZoomType2()
    {
        ZoomPanel.instance.SetRenderCamera(zoomCamera);
        zoomCamera.gameObject.SetActive(true);
        CameraManager.instance.SetZoomCamera_ZoomType2(zoomCamera);
        CloseAnimManeger.instance.CloseAnim();
    }

    //1階：1段階目のズーム(ベランダ)のカメラに遷移
    public void OnClickObj_Out()
    {
        ZoomPanel.instance.SetRenderCamera(zoomCamera);
        zoomCamera.gameObject.SetActive(true);
        CameraManager.instance.SetZoomCamera_Out(zoomCamera);
        CloseAnimManeger.instance.CloseAnim();
    }

    //1階：ベランダのカメラに遷移からメインカメラに遷移
    public void OnClickObj_In()
    {
        ZoomPanel.instance.SetRenderCamera(Camera.main);
        CameraManager.instance.SetZoomCamera_In();
        CloseAnimManeger.instance.CloseAnim();
    }

    //1階：3段階以上のズーム
    public void OnClickObj_ZoomPlus()
    {
        ZoomPanel.instance.SetRenderCamera(zoomCamera);
        zoomCamera.gameObject.SetActive(true);
        CameraManager.instance.SetZoomCamera_ZoomPlus(zoomCamera);
        CloseAnimManeger.instance.CloseAnim();
    }

    //2階：1階のカメラから2階のカメラに遷移
    public void OnClickObj_MoveFloor2()
    {
        ZoomPanel.instance.SetRenderCamera(zoomCamera);
        zoomCamera.gameObject.SetActive(true);
        CameraManager.instance.SetZoomCamera_MoveFloor2(zoomCamera);
        CloseAnimManeger.instance.CloseAnim();
    }

    //2階：1段階目のズーム
    public void OnClickObj_ZoomFloor2()
    {
        ZoomPanel.instance.SetRenderCamera(zoomCamera);
        zoomCamera.gameObject.SetActive(true);
        CameraManager.instance.SetZoomCamera_ZoomFloor2(zoomCamera);
        CloseAnimManeger.instance.CloseAnim();
    }

    //2階：2段階目以上のズーム
    public void OnClickObj_ZoomPlusFloor2()
    {
        ZoomPanel.instance.SetRenderCamera(zoomCamera);
        zoomCamera.gameObject.SetActive(true);
        CameraManager.instance.SetZoomCamera_ZoomPlusFloor2(zoomCamera);
        CloseAnimManeger.instance.CloseAnim();
    }

    //public void OnClickObj()
    //{
    //    ZoomPanel.instance.SetRenderCamera(zoomCamera);
    //    zoomCamera.gameObject.SetActive(true);
    //    CameraManager.instance.SetZoomCamera(zoomCamera);
    //    CloseAnimManeger.instance.CloseAnim();
    //}


}
