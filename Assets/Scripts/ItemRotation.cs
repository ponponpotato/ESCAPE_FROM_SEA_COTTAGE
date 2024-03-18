using UnityEngine;

//�A�C�e���̉�]�N���X

public class ItemRotation : MonoBehaviour
{
    //��]��(�e�I�u�W�F�N�g)��Transform
    [SerializeField] Transform ParentAxis;

    //��]���x�̒����p
    float k = 1000f;

    //�^�b�`�ŃA�C�e������]
    private Vector2 touchStartPos;

    // �^�b�`���x
    float touchSensitivity = 0.01f;


    void Update()
    {
        if (ZoomPanel.instance.SelectedItem.type != Item.Type.Remocon) return;

        if (Input.touchCount > 0)
        {
            //�ŏ��̃^�b�`���擾
            Touch touch = Input.GetTouch(0);

            
            if (touch.phase == TouchPhase.Began)//�^�b�`�̃t�F�[�Y���n�܂����Ƃ�
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)//�^�b�`�������Ă��鎞
            {
                float touchDeltaX = touch.position.x - touchStartPos.x;
                float x = -touchDeltaX * touchSensitivity * Time.deltaTime * k;

                transform.RotateAround(transform.position, Quaternion.Euler(ParentAxis.rotation.eulerAngles) * Vector3.up, x);
            }

        }

    }

}
