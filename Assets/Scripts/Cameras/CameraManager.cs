using System.Collections.Generic;
using UnityEngine;

//カメラの管理クラス　現在のカメラに応じてUIを切り替える

public class CameraManager : MonoBehaviour
{

    //どこからでもアクセスできるようにする
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

    //メインカメラ：左移動ボタンクリックされたとき
    public void TurnLeft()
    {
        currentIndex++;
        if (currentIndex >= cameraPositions.Length) currentIndex = 0;
        SetCameraPosition();
        ZoomPanel.instance.HideZoomPanel();
    }

    //メインカメラ：右移動ボタンクリックされたとき
    public void TurnRight()
    {
        currentIndex--;
        if (currentIndex < 0) currentIndex = cameraPositions.Length-1;
        SetCameraPosition();
        ZoomPanel.instance.HideZoomPanel();
    }

    //一階関連：ズーム後のカメラから1段階前のカメラに戻るとき
    public void OnBack()
    {
        CloseAnimManeger.instance.CloseAnim(); //開いているオブジェクトあったら閉じる
        ZoomPanel.instance.HideZoomPanel();    //アイテムズームのパネルが表示されていた場合は閉じる

        switch (SubCamera)
        {

            case null:　//SubCameraなし

                this.zoomCamera.gameObject.SetActive(false);
                MainCamera.gameObject.SetActive(true);
                ZoomPanel.instance.SetRenderCamera(MainCamera);
                backButton.SetActive(false);
                leftButton.SetActive(true);
                rightButton.SetActive(true);
                return;

            default:　//SubCameraあり

                
                if (PlusZoomCount == 0) //3段階未満のズームの時
                {
                    
                    PlusZoomCameraList.Clear();

                    switch (ZoomType)
                    {
                        case 0: //MainCameraに戻る *1段階目ズームからメインカメラ

                            SubCamera.gameObject.SetActive(false);
                            MainCamera.gameObject.SetActive(true);
                            ZoomPanel.instance.SetRenderCamera(MainCamera);
                            backButton.SetActive(false);
                            leftButton.SetActive(true);
                            rightButton.SetActive(true);
                            SubCamera = null;
                            return;

                        case 1: //BackButtonありのSubCameraに戻る 

                            this.zoomCamera.gameObject.SetActive(false);
                            SubCamera.gameObject.SetActive(true);
                            ZoomPanel.instance.SetRenderCamera(SubCamera);
                            ZoomType = 0;
                            return;

                        case 2: //BackButtonなしのSubCameraに戻る(ベランダでのカメラ)

                            this.zoomCamera.gameObject.SetActive(false);
                            backButton.SetActive(false);
                            ZoomPanel.instance.SetRenderCamera(SubCamera);
                            SubCamera.gameObject.SetActive(true);
                            ZoomType = 0;
                            return;

                    }
                    
                }
                else //3段階以上のズームがあるとき
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

    //メインカメラ(1階)のポジション変更
    public void SetCameraPosition()
    {
        MainCamera.transform.position = cameraPositions[currentIndex].position;
        MainCamera.transform.rotation = cameraPositions[currentIndex].rotation;
    }


    //SubCameraに移動　＊ズームとしては1段階目
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

    //BackButtonありのSubCameraからさらにズームするとき ＊ズームとしては2段階目
    public void SetZoomCamera_ZoomType1(Camera zoomCamera)
    {
        this.zoomCamera = zoomCamera;
        backButton.SetActive(true);
        SubCamera.gameObject.SetActive(false);
        PlusZoomCameraList.Add(this.zoomCamera);
        ZoomType = 1;
    }

    //BackButtonなしのSubCameraからさらにズームするとき(ベランダに移動した際はBackButtonがないため) ＊ズームとしては2段階目
    public void SetZoomCamera_ZoomType2(Camera zoomCamera)
    {
        this.zoomCamera = zoomCamera;
        backButton.SetActive(true);
        SubCamera.gameObject.SetActive(false);
        PlusZoomCameraList.Add(this.zoomCamera);
        ZoomType = 2;
    }

    //メインカメラから3段階以上のズームが必要な時
    public void SetZoomCamera_ZoomPlus(Camera zoomCamera)
    {
        this.zoomCamera.gameObject.SetActive(false);
        this.zoomCamera = zoomCamera;
        PlusZoomCameraList.Add(this.zoomCamera);
        PlusZoomCount++;
    }

    //ベランダに移動するとき　＊ズームとしては1段階目
    public void SetZoomCamera_Out(Camera zoomCamera)
    {
        this.zoomCamera = zoomCamera;
        backButton.SetActive(false);
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        MainCamera.gameObject.SetActive(false);
        SubCamera = this.zoomCamera;
    }

    //ベランダから中に戻るとき
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

    //メインカメラ(2階)：右移動ボタンクリックされたとき
    public void TurnRight_Floor2()
    {
        MainCamera_Floor2.transform.position = cameraPositions_Floor2[1].position;
        MainCamera_Floor2.transform.rotation = cameraPositions_Floor2[1].rotation;
        rightButton_floor2.SetActive(false);
        leftButton_floor2.SetActive(true);
        LeftButtonIsLast = true;
        ZoomPanel.instance.HideZoomPanel();
    }

    //メインカメラ(2階)：左移動ボタンクリックされたとき
    public void TurnLeft_Floor2()
    {
        MainCamera_Floor2.transform.position = cameraPositions_Floor2[0].position;
        MainCamera_Floor2.transform.rotation = cameraPositions_Floor2[0].rotation;
        rightButton_floor2.SetActive(true);
        leftButton_floor2.SetActive(false);
        LeftButtonIsLast = false;
        ZoomPanel.instance.HideZoomPanel();
    }

    //2階関連：ズーム後のカメラからズーム前のカメラに戻る
    public void OnBack_Floor2()
    {

        CloseAnimManeger.instance.CloseAnim();
        ZoomPanel.instance.HideZoomPanel();

        switch (SubCamera_Floor2)
        {

            case null://SubCamera_Floor2=nullの場合は1階に戻り、1階のSubCamera・UIをアクティブに

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

                if (PlusZoomCount == 0)//2段階以上のズームがないとき
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
                else//2段階以上のズームがあるとき
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

    //1階から2階に移動したとき
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

    //2階のメインカメラから1段階目のズームした時
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

    //2階のメインカメラから2段階以上のズームをする必要があるとき
    public void SetZoomCamera_ZoomPlusFloor2(Camera zoomCamera)
    {
        this.zoomCamera_Floor2.gameObject.SetActive(false);
        this.zoomCamera_Floor2 = zoomCamera;
        PlusZoomCameraList.Add(this.zoomCamera_Floor2);
        PlusZoomCount++;
    }


}
