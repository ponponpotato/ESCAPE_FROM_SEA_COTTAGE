using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;



//�Q�[���v���C�X�^�[�g���ɃA�N�e�B�u�E��A�N�e�B�u���������

public class StartMenu : MonoBehaviour
{
    [SerializeField] GameObject StartMenuCanvas = default;
    [SerializeField] GameObject ItemBoxCanvas = default;
    [SerializeField] GameObject CameraCanvas = default;
    [SerializeField] GameObject CameraManager = default;

    public static StartMenu instance;

    //�Z�[�u�f�[�^�̕ۑ���p�X
    private string saveDataPath = System.IO.Directory.GetCurrentDirectory() + @"\SAVEDATA.txt";

    //�Z�[�u�f�[�^�����݂���Ƃ��̑��s�m�F�_�C�A���O�̃I�u�W�F�N�g
    [SerializeField] GameObject dialogPanel = default;

    private void Awake()
    {
        instance = this;
    }

    public async void onClickStartButton()
    {
        //�Z�[�u�f�[�^���݂���ꍇ�́A�Z�[�u�f�[�^�폜���Ă͂��߂���X�^�[�g���邩�m�F
        if(System.IO.File.Exists(saveDataPath)==true)
        {
            dialogPanel.SetActive(true);
            Button[] chidButtons = dialogPanel.GetComponentsInChildren<Button>();
            Button yesButton = chidButtons[0];
            Button noButton = chidButtons[1];

            //�u�͂��v�������́u�������v�{�^�����I�������܂őҋ@
            string result = await yesButton.OnClickAsObservable().Select(_ => "�͂�")
                        .Merge(
                                noButton.OnClickAsObservable().Select(_ => "������")
                                )
                        .ToUniTask(useFirstValue: true);

            //�u�͂��v�Ȃ�Z�[�u�f�[�^�폜���ăQ�[���X�^�[�g�u�������v�Ȃ�_�C�A���O��\��
            if (result == "�͂�")
            {
                System.IO.File.Delete(saveDataPath);
                GamePlay();
            }
            else
            {
                dialogPanel.SetActive(false);
            }

        }
        else
        {
            GamePlay();
        }
    }

    public void GamePlay()
    {
        ItemBoxCanvas.SetActive(true);
        CameraCanvas.SetActive(true);
        CameraManager.SetActive(true);
        StartMenuCanvas.SetActive(false);
    }
}
