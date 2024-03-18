using UnityEngine;

//�}�e���A���摜�̕ύX�N���X

public class ImageChanger : MonoBehaviour
{
    [SerializeField] Material[] Materials = default;
    [SerializeField] GimmickStatus.Type type;

    //PassWordCheck�N���X�Ŋe�p�X���[�h�{�^����number�𐳉��̃p�X���[�h�ƏƂ炵���킹��
    public int number = 0;

    private void Start()
    {
        number = 0;
    }

    //�N���b�N����ƃ}�e���A����number���{�P���ĕύX
    public void OnClickThis()
    {
        if (GimmickStatusManager.instance.StatusCheck(type) == true) return;

        number++;
        if (number > Materials.Length - 1)//�z��̗̈撴������A0�Ƀ��Z�b�g
        {
            number = 0;
        }
        gameObject.GetComponent<Renderer>().material = Materials[number];

    }

}