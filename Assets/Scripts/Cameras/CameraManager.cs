using System.Collections.Generic;
using UnityEngine;

//�J�����̊Ǘ��N���X�@���݂̃J�����ɉ�����UI��؂�ւ���

public class CameraManager : MonoBehaviour
{

    //�ǂ�����ł��A�N�Z�X�ł���悤�ɂ���
    public static CameraManager instance;

    [SerializeField] GameObject backButton = default;
    [SerializeField] GameObject leftButton = default;
    [SerializeField] GameObject rightButton = default;
    [SerializeField] GameObject backButton_floor2 = default;
    [SerializeField] GameObject leftButton_floor2 = default;
    [SerializeField] GameObject rightButton_floor2 = default;
    [SerializeField] Transform[] cameraPositions = default;
    [SerializeField] Transform[] cameraPositions_Floor2 = default;


    int currentIndex = 0;
    int ZoomType = 0;
    Camera MainCamera = null;
    Camera MainCamera_Floor2 = null;
    Camera SubCamera = null;
    Camera SubCamera_Floor2 = null;
    Camera zoomCamera = null;
    Camera zoomCamera_Floor2 = null;
    List<Camera> PlusZoomCameraList = new List<Camera>();
    bool LeftButtonIsLast = false;
    int PlusZoomCount = 0;
    public bool LoadStart = false;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        MainCamera = Camera.main;
        currentIndex = 0;
        SetCameraPosition();
        backButton.SetActive(false);
    }

    //���C���J�����F���ړ��{�^���N���b�N���ꂽ�Ƃ�
    public void TurnLeft()
    {
        currentIndex++;
        if (currentIndex >= cameraPositions.Length) currentIndex = 0;
        SetCameraPosition();
        ZoomPanel.instance.HideZoomPanel();
    }

    //���C���J�����F�E�ړ��{�^���N���b�N���ꂽ�Ƃ�
    public void TurnRight()
    {
        currentIndex--;
        if (currentIndex < 0) currentIndex = cameraPositions.Length-1;
        SetCameraPosition();
        ZoomPanel.instance.HideZoomPanel();
    }

    //��K�֘A�F�Y�[����̃J��������1�i�K�O�̃J�����ɖ߂�Ƃ�
    public void OnBack()
    {
        CloseAnimManeger.instance.CloseAnim(); //�J���Ă���I�u�W�F�N�g�����������
        ZoomPanel.instance.HideZoomPanel();    //�A�C�e���Y�[���̃p�l�����\������Ă����ꍇ�͕���

        switch (SubCamera)
        {

            case null:�@//SubCamera�Ȃ�

                this.zoomCamera.gameObject.SetActive(false);
                MainCamera.gameObject.SetActive(true);
                ZoomPanel.instance.SetRenderCamera(MainCamera);
                backButton.SetActive(false);
                leftButton.SetActive(true);
                rightButton.SetActive(true);
                return;

            default:�@//SubCamera����

                
                if (PlusZoomCount == 0) //3�i�K�����̃Y�[���̎�
                {
                    
                    PlusZoomCameraList.Clear();

                    switch (ZoomType)
                    {
                        case 0: //MainCamera�ɖ߂� *1�i�K�ڃY�[�����烁�C���J����

                            SubCamera.gameObject.SetActive(false);
                            MainCamera.gameObject.SetActive(true);
                            ZoomPanel.instance.SetRenderCamera(MainCamera);
                            backButton.SetActive(false);
                            leftButton.SetActive(true);
                            rightButton.SetActive(true);
                            SubCamera = null;
                            return;

                        case 1: //BackButton�����SubCamera�ɖ߂� 

                            this.zoomCamera.gameObject.SetActive(false);
                            SubCamera.gameObject.SetActive(true);
                            ZoomPanel.instance.SetRenderCamera(SubCamera);
                            ZoomType = 0;
                            return;

                        case 2: //BackButton�Ȃ���SubCamera�ɖ߂�(�x�����_�ł̃J����)

                            this.zoomCamera.gameObject.SetActive(false);
                            backButton.SetActive(false);
                            ZoomPanel.instance.SetRenderCamera(SubCamera);
                            SubCamera.gameObject.SetActive(true);
                            ZoomType = 0;
                            return;

                    }
                    
                }
                else //3�i�K�ȏ�̃Y�[��������Ƃ�
                {
                    this.zoomCamera.gameObject.SetActive(false);
                    PlusZoomCount--;
                    this.zoomCamera = PlusZoomCameraList[PlusZoomCount];
                    this.zoomCamera.gameObject.SetActive(true);
                    ZoomPanel.instance.SetRenderCamera(this.zoomCamera);
                    backButton.SetActive(true);

                }

                return;

        }

    }

    //���C���J����(1�K)�̃|�W�V�����ύX
    public void SetCameraPosition()
    {
        MainCamera.transform.position = cameraPositions[currentIndex].position;
        MainCamera.transform.rotation = cameraPositions[currentIndex].rotation;
    }


    //SubCamera�Ɉړ��@���Y�[���Ƃ��Ă�1�i�K��
    public void SetZoomCamera_ZoomType0(Camera zoomCamera)
    {
        SubCamera = zoomCamera;
        backButton.SetActive(true);
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        MainCamera.gameObject.SetActive(false);
        SubCamera.gameObject.SetActive(true);
        ZoomType = 0;
    }

    //BackButton�����SubCamera���炳��ɃY�[������Ƃ� ���Y�[���Ƃ��Ă�2�i�K��
    public void SetZoomCamera_ZoomType1(Camera zoomCamera)
    {
        this.zoomCamera = zoomCamera;
        backButton.SetActive(true);
        SubCamera.gameObject.SetActive(false);
        PlusZoomCameraList.Add(this.zoomCamera);
        ZoomType = 1;
    }

    //BackButton�Ȃ���SubCamera���炳��ɃY�[������Ƃ�(�x�����_�Ɉړ������ۂ�BackButton���Ȃ�����) ���Y�[���Ƃ��Ă�2�i�K��
    public void SetZoomCamera_ZoomType2(Camera zoomCamera)
    {
        this.zoomCamera = zoomCamera;
        backButton.SetActive(true);
        SubCamera.gameObject.SetActive(false);
        PlusZoomCameraList.Add(this.zoomCamera);
        ZoomType = 2;
    }

    //���C���J��������3�i�K�ȏ�̃Y�[�����K�v�Ȏ�
    public void SetZoomCamera_ZoomPlus(Camera zoomCamera)
    {
        this.zoomCamera.gameObject.SetActive(false);
        this.zoomCamera = zoomCamera;
        PlusZoomCameraList.Add(this.zoomCamera);
        PlusZoomCount++;
    }

    //�x�����_�Ɉړ�����Ƃ��@���Y�[���Ƃ��Ă�1�i�K��
    public void SetZoomCamera_Out(Camera zoomCamera)
    {
        this.zoomCamera = zoomCamera;
        backButton.SetActive(false);
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        MainCamera.gameObject.SetActive(false);
        SubCamera = this.zoomCamera;
    }

    //�x�����_���璆�ɖ߂�Ƃ�
    public void SetZoomCamera_In()
    {
        this.zoomCamera.gameObject.SetActive(false);
        leftButton.SetActive(true);
        rightButton.SetActive(true);
        SubCamera.gameObject.SetActive(false);
        SubCamera = null;
        MainCamera.gameObject.SetActive(true);
    }



    //Floor2

    //���C���J����(2�K)�F�E�ړ��{�^���N���b�N���ꂽ�Ƃ�
    public void TurnRight_Floor2()
    {
        MainCamera_Floor2.transform.position = cameraPositions_Floor2[1].position;
        MainCamera_Floor2.transform.rotation = cameraPositions_Floor2[1].rotation;
        rightButton_floor2.SetActive(false);
        leftButton_floor2.SetActive(true);
        LeftButtonIsLast = true;
        ZoomPanel.instance.HideZoomPanel();
    }

    //���C���J����(2�K)�F���ړ��{�^���N���b�N���ꂽ�Ƃ�
    public void TurnLeft_Floor2()
    {
        MainCamera_Floor2.transform.position = cameraPositions_Floor2[0].position;
        MainCamera_Floor2.transform.rotation = cameraPositions_Floor2[0].rotation;
        rightButton_floor2.SetActive(true);
        leftButton_floor2.SetActive(false);
        LeftButtonIsLast = false;
        ZoomPanel.instance.HideZoomPanel();
    }

    //2�K�֘A�F�Y�[����̃J��������Y�[���O�̃J�����ɖ߂�
    public void OnBack_Floor2()
    {

        CloseAnimManeger.instance.CloseAnim();
        ZoomPanel.instance.HideZoomPanel();

        switch (SubCamera_Floor2)
        {

            case null://SubCamera_Floor2=null�̏ꍇ��1�K�ɖ߂�A1�K��SubCamera�EUI���A�N�e�B�u��

                MainCamera_Floor2.gameObject.SetActive(false);
                SubCamera.gameObject.SetActive(true);
                ZoomPanel.instance.SetRenderCamera(SubCamera);
                leftButton_floor2.SetActive(false);
                rightButton_floor2.SetActive(false);
                backButton_floor2.SetActive(false);
                backButton.SetActive(true);
                return;

            default:
                this.zoomCamera_Floor2.gameObject.SetActive(false);

                if (PlusZoomCount == 0)//2�i�K�ȏ�̃Y�[�����Ȃ��Ƃ�
                {
                    MainCamera_Floor2.gameObject.SetActive(true);
                    ZoomPanel.instance.SetRenderCamera(MainCamera_Floor2);
                    SubCamera_Floor2 = null;

                    if (LeftButtonIsLast == true) 
                    {
                        leftButton_floor2.SetActive(true);
                    }
                    else
                    {
                        rightButton_floor2.SetActive(true);
                    }
                    PlusZoomCameraList.Clear();
                }
                else//2�i�K�ȏ�̃Y�[��������Ƃ�
                {
                    PlusZoomCount--;
                    this.zoomCamera_Floor2 = PlusZoomCameraList[PlusZoomCount];
                    this.zoomCamera_Floor2.gameObject.SetActive(true);
                    ZoomPanel.instance.SetRenderCamera(zoomCamera_Floor2);
                    Debug.Log(PlusZoomCount);
                }

                backButton_floor2.SetActive(true);

                return;

        }

    }

    //1�K����2�K�Ɉړ������Ƃ�
    public void SetZoomCamera_MoveFloor2(Camera zoomCamera)
    {
        SubCamera.gameObject.SetActive(false);
        MainCamera_Floor2 = zoomCamera;
        backButton.SetActive(false);
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        backButton_floor2.SetActive(true);
        TurnLeft_Floor2();
    }

    //2�K�̃��C���J��������1�i�K�ڂ̃Y�[��������
    public void SetZoomCamera_ZoomFloor2(Camera zoomCamera)
    {
        this.zoomCamera_Floor2 = zoomCamera;
        backButton_floor2.SetActive(true);
        leftButton_floor2.SetActive(false);
        rightButton_floor2.SetActive(false);
        MainCamera_Floor2.gameObject.SetActive(false);
        SubCamera_Floor2 = this.zoomCamera_Floor2;
        PlusZoomCameraList.Add(SubCamera_Floor2);
    }

    //2�K�̃��C���J��������2�i�K�ȏ�̃Y�[��������K�v������Ƃ�
    public void SetZoomCamera_ZoomPlusFloor2(Camera zoomCamera)
    {
        this.zoomCamera_Floor2.gameObject.SetActive(false);
        this.zoomCamera_Floor2 = zoomCamera;
        PlusZoomCameraList.Add(this.zoomCamera_Floor2);
        PlusZoomCount++;
    }


}
