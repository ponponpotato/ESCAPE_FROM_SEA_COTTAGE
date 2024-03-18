using UnityEngine;
using TMPro;

//Hint�ȊO�̃��b�Z�[�W��\������N���X

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

    //���b�Z�[�W�̕\���@���L���ŃQ�b�g�ł���q���g�ȊO�@ex)�d�r�������Ă��Ȃ��Ȃ�
    public void ShowMessage(string message)
    {
        if (IsShown == true) return;
        IsShown = true;
        MessagePanel.SetActive(true);
        Message.text = message;
        Invoke("HideMessage", 2.0f); //2�b�ԕ\��
    }

    void HideMessage()
    {
        IsShown = false;
        Message.text = "";
        MessagePanel.SetActive(false);
    }
}
