using UnityEngine;

//�z�[��(���C�����j���[)�ɋA��E��������Hint��\������L�����o�X�̋����Ǘ�

public class ReturnHomeCanvas : MonoBehaviour
{

    [SerializeField] GameObject ParentPanel = default;
    [SerializeField] GameObject HintPanel = default;
    //bool IsShow = false;

    //�e�p�l���̕\��
    public void ShowParentPanel()
    {
        ParentPanel.SetActive(true);
        //IsShow = true;
    }

    //�e�p�l���̔�\��
    public void HideParentPanel()
    {
        ParentPanel.SetActive(false);
        //IsShow = false;
    }

    //�q���g�p�l���̔�\��
    public void HideHintPanel()
    {
        HintPanel.SetActive(false);
    }
}
