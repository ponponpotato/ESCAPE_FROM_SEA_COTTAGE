using UnityEngine;
using UnityEngine.Events;

//正解のパスワードになっているかを判別

public class PassWordCheck : MonoBehaviour
{
    //正解すると、設定されたイベントを実行する（UnityEvent）
    public UnityEvent ClearEvent;

    [SerializeField] GimmickStatus.Type type = default;

    //正解番号の配列 
    [SerializeField] int[] CorrectNumbers;

    //現在の数値:PassWordButtonのNumberを参照すればよい
    [SerializeField] Password_Changer[] PassWordButtons;
    [SerializeField] ImageChanger[] ImageButtons;


    //数値orアルファベットのパスワードのボタンがクリックされるたびに正解パスワードと比較
    public void PassCheck()
    {
        if (IsClear() == true)
        {
            GimmickStatusManager.instance.StatusChanger(type);
            ClearEvent.Invoke();
            SoundManager.instance.PlaySound(SoundManager.instance.GimmickClearSound);
        }
    }


    //正解パスワードの数値が対応する各ボタンの現在の数値(number)と一致しているか確認　
    bool IsClear()
    {

        for (int i = 0; i < CorrectNumbers.Length; i++)
        {
            if (CorrectNumbers[i] != PassWordButtons[i].number)
            {
                return false;
            }
        }
        return true;

    }

    //画像(マテリアル)のパスワードのボタンがクリックされるたびに正解パスワードと比較
    public void PassCheck_Image()
    {
        if (IsClear_Image() == true)
        {
            GimmickStatusManager.instance.StatusChanger(type);
            ClearEvent.Invoke();
            SoundManager.instance.PlaySound(SoundManager.instance.GimmickClearSound);
        }
    }

    //正解パスワードの数値が対応する各ボタンの現在の数値(number)と一致しているか確認　
    bool IsClear_Image()
    {

        for (int i = 0; i < CorrectNumbers.Length; i++)
        {
            if (CorrectNumbers[i] != ImageButtons[i].number)
            {
                return false;
            }
        }
        return true;

    }
}
