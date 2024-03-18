using UnityEngine;
using TMPro;

//�M�~�b�N�p�X���[�h�̕ύX�N���X(�p�X���[�h�̃{�^���̃N���b�N�ɉ����Đ��l��A���t�@�x�b�g��ύX)

public class Password_Changer: MonoBehaviour
{
    [SerializeField] TMP_Text numberText;
    [SerializeField] GimmickStatus.Type type;
    public string[] Alphabets;

    //PassWordCheck�N���X�Ŋe�p�X���[�h�{�^����number�𐳉��̃p�X���[�h�ƏƂ炵���킹��
    public int number = 0;

    private void Start()
    {
        number = 0;
        if (Alphabets.Length > 0)
        {
            numberText.text = Alphabets[0];
        }
        else{
            numberText.text = number.ToString();
        }
    }

    //1~12�̃p�X���[�h
    public void OnClickThis()
    {
        if (GimmickStatusManager.instance.StatusCheck(type) == true) return;

        number++;
        if (number > 12)
        {
            number = 0;
        }
        numberText.text = number.ToString();

    }

    //0~9�̃p�X���[�h
    public void OnClickThis_09()
    {
        if (GimmickStatusManager.instance.StatusCheck(type) == true) return;

        number++;
        if (number > 9)
        {
            number = 0;
        }
        numberText.text = number.ToString();

    }

    //�A���t�@�x�b�g�̃p�X���[�h
    public void OnClickThis_Alphabet()
    {
        Debug.Log(type.ToString());
        if (GimmickStatusManager.instance.StatusCheck(type) == true) return;

        number++;
        if (number > Alphabets.Length - 1)
        {
            number = 0;
        }
        numberText.text = Alphabets[number];

    }

}
