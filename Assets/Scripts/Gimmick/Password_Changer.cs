using UnityEngine;
using TMPro;

//ギミックパスワードの変更クラス(パスワードのボタンのクリックに応じて数値やアルファベットを変更)

public class Password_Changer: MonoBehaviour
{
    [SerializeField] TMP_Text numberText;
    [SerializeField] GimmickStatus.Type type;
    public string[] Alphabets;

    //PassWordCheckクラスで各パスワードボタンのnumberを正解のパスワードと照らし合わせる
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

    //1~12のパスワード
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

    //0~9のパスワード
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

    //アルファベットのパスワード
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
