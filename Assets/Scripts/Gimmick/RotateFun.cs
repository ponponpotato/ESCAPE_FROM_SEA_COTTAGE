using UnityEngine;

//�V�[�����O�t�@���̉�]�N���X

public class RotateFun : MonoBehaviour
{

    public float rotateX = 0;
    public float rotateY = 0;
    public float rotateZ = 0;

    //�d���X�C�b�`��ON�Ȃ�V�[�����O�t�@������]������
    void Update()
    {
        // X,Y,Z���ɑ΂��Ă��ꂼ��A�w�肵���p�x����]�����Ă���B
        // deltaTime�������邱�ƂŁA�t���[�����Ƃł͂Ȃ��A1�b���Ƃɉ�]����悤�ɂ��Ă���B
        if (GimmickStatusManager.instance.switchGimmick == false) return;
        gameObject.transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * Time.deltaTime);
    }
}
