using UnityEngine;
using TMPro;

//Hint以外のメッセージを表示するクラス

public class MessageShow : MonoBehaviour
{
    [SerializeField] GameObject MessagePanel = default;
    [SerializeField] TextMeshProUGUI Message;
    public bool IsShown = false;
    public static MessageShow instance;

    private void Start()
    {
        Message.text = "";
        instance = this;
    }

    //メッセージの表示　＊広告でゲットできるヒント以外　ex)電池が入っていないなど
    public void ShowMessage(string message)
    {
        if (IsShown == true) return;
        IsShown = true;
        MessagePanel.SetActive(true);
        Message.text = message;
        Invoke("HideMessage", 2.0f); //2秒間表示
    }

    void HideMessage()
    {
        IsShown = false;
        Message.text = "";
        MessagePanel.SetActive(false);
    }
}
