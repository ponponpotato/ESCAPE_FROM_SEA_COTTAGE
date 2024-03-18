using UnityEngine;

// zoom��̃J�����̐ݒ������N���X�@��CameraMnager�N���X�ōׂ��������͍s��

public class ZoomCameraSetter : MonoBehaviour
{
    // �N���b�N���ꂽ��Y�[���p�̃J�����ɐ؂�ւ���
    [SerializeField] Camera zoomCamera = default;

    //1�K�F1�i�K�ڂ̃Y�[��
    public void OnClickObj_ZoomType0()
    {
        ZoomPanel.instance.SetRenderCamera(zoomCamera);
        zoomCamera.gameObject.SetActive(true);
        CameraManager.instance.SetZoomCamera_ZoomType0(zoomCamera);
        CloseAnimManeger.instance.CloseAnim();
    }

    //1�K�F2�i�K�ڂ̃Y�[��(BackButton����)
    public void OnClickObj_ZoomType1()
    {
        ZoomPanel.instance.SetRenderCamera(zoomCamera);
        zoomCamera.gameObject.SetActive(true);
        CameraManager.instance.SetZoomCamera_ZoomType1(zoomCamera);
        CloseAnimManeger.instance.CloseAnim();
    }

    //1�K�F2�i�K�ڂ̃Y�[��(BackButton�Ȃ�)���x�����_�̃J�������炳��ɃY�[������p�^�[��
    public void OnClickObj_ZoomType2()
    {
        ZoomPanel.instance.SetRenderCamera(zoomCamera);
        zoomCamera.gameObject.SetActive(true);
        CameraManager.instance.SetZoomCamera_ZoomType2(zoomCamera);
        CloseAnimManeger.instance.CloseAnim();
    }

    //1�K�F1�i�K�ڂ̃Y�[��(�x�����_)�̃J�����ɑJ��
    public void OnClickObj_Out()
    {
        ZoomPanel.instance.SetRenderCamera(zoomCamera);
        zoomCamera.gameObject.SetActive(true);
        CameraManager.instance.SetZoomCamera_Out(zoomCamera);
        CloseAnimManeger.instance.CloseAnim();
    }

    //1�K�F�x�����_�̃J�����ɑJ�ڂ��烁�C���J�����ɑJ��
    public void OnClickObj_In()
    {
        ZoomPanel.instance.SetRenderCamera(Camera.main);
        CameraManager.instance.SetZoomCamera_In();
        CloseAnimManeger.instance.CloseAnim();
    }

    //1�K�F3�i�K�ȏ�̃Y�[��
    public void OnClickObj_ZoomPlus()
    {
        ZoomPanel.instance.SetRenderCamera(zoomCamera);
        zoomCamera.gameObject.SetActive(true);
        CameraManager.instance.SetZoomCamera_ZoomPlus(zoomCamera);
        CloseAnimManeger.instance.CloseAnim();
    }

    //2�K�F1�K�̃J��������2�K�̃J�����ɑJ��
    public void OnClickObj_MoveFloor2()
    {
        ZoomPanel.instance.SetRenderCamera(zoomCamera);
        zoomCamera.gameObject.SetActive(true);
        CameraManager.instance.SetZoomCamera_MoveFloor2(zoomCamera);
        CloseAnimManeger.instance.CloseAnim();
    }

    //2�K�F1�i�K�ڂ̃Y�[��
    public void OnClickObj_ZoomFloor2()
    {
        ZoomPanel.instance.SetRenderCamera(zoomCamera);
        zoomCamera.gameObject.SetActive(true);
        CameraManager.instance.SetZoomCamera_ZoomFloor2(zoomCamera);
        CloseAnimManeger.instance.CloseAnim();
    }

    //2�K�F2�i�K�ڈȏ�̃Y�[��
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
