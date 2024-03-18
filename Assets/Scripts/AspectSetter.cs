using System.Collections.Generic;
using UnityEngine;

//�𑜓x�Ή��p�̃N���X

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

    //�ڕW�̃A�X�y�N�g��
    float targetAspect()
    {
        return (float)720 / 1280;
    }

    //Camera��FieldView���𑜓x�ɍ��킹��
    void adjustCamera()
    {
        float currentAspectRatio = (float)Screen.width / Screen.height;
        float targetAspectRatio = targetAspect();

        //�����̃J�������ׂĂ̎���p���A�X�y�N�g��ɉ����ĕύX
        foreach (Camera targetCamera in cameraList)
        {
            targetCamera.aspect = targetAspectRatio;

            //�c�̎���p���ݒ�ς݂̎���p�Ƃ��Ď擾
            //X�����̎���p�̓A�X�y�N�g������ƂɎZ�o�ł���
            float DefaultFov = targetCamera.fieldOfView;

            if (currentAspectRatio < targetAspectRatio)
            {

                //Y�����̎���p����X�����̎���p���v�Z�i�J�����̎���p��Y������ƂȂ��Ă��邽�߁j
                targetCamera.fieldOfView = calculateHorizontalFOV(DefaultFov, currentAspectRatio / targetAspectRatio);

            }

        }

    }

    //x�����̎���p�̌v�Z
    float calculateHorizontalFOV(float fovY, float aspect)
    {
        float radY = fovY * Mathf.Deg2Rad;
        float radX = 2 * Mathf.Atan(Mathf.Tan(radY / 2) / aspect);
        float fovX = radX * Mathf.Rad2Deg;
        return fovX;
    }

    //���ꂢ��Ȃ�
    //void cameraAspectSet()
    //{

    //    float screenAspect = Screen.width / (float)Screen.height; //��ʂ̃A�X�y�N�g��
    //    float targetAspect = this.targetAspect();                 //�^�[�Q�b�g�̃A�X�y�N�g��
    //    float mergeRate = targetAspect / screenAspect;�@�@�@�@�@�@ //�ړI�A�X�y�N�g��ɂ��邽�߂̔{��

    //    Debug.Log(mergeRate);

    //    viewportRect = new Rect(0, 0, 1, 1); //viewport�����l��Rect���쐬

    //    if (mergeRate < 1)
    //    {
    //        viewportRect.width = mergeRate;                   //�g�p���鉡����ύX
    //        viewportRect.x = 0.5f - viewportRect.width * 0.5f;//������
    //    }
    //    else
    //    {
    //        viewportRect.height = 1 / mergeRate;               //�g�p����c����ύX
    //        viewportRect.y = 0.5f - viewportRect.height * 0.5f;//������
    //    }

    //    foreach (Camera camera in cameraList)
    //    {
    //        camera.rect = viewportRect; //�J������Viewport�ɓK�p
    //    }

    //}



}
