using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//�Z�[�u�ƃ��[�h�N���X

public class SaveLoadData : MonoBehaviour
{
    //�Z�[�u����I�u�W�F�N�g�̃��X�g
    public List<GameObject> gameObjects;

    //�Z�[�u�E���[�h���̉摜�I�u�W�F�N�g
    public GameObject loadImage = default;

    //���[�h�{�^���I�u�W�F�N�g
    public GameObject loadButton = default;

    //�Z�[�u�f�[�^�̕ۑ���p�X
    private string saveDataPath = default;

    //�Z�[�u�f�[�^��stringBuilder�ō쐬 string��荂��
    private StringBuilder saveDataBuilder;

    //���[�h�f�[�^��Dictionary�Ŋm��
    private Dictionary<string, string> loadDataDictionay;


    bool loadImageIsActive = false;

    private void Start()
    {
        //�Z�[�u�f�[�^�̃p�X�ݒ�iGetCurrentDirrectory�ł͂Ȃ�Application.persistentDataPath���g�p�FAndroid���@�ł͂��ꂶ��Ȃ��ƃ_���j
        saveDataPath = Application.persistentDataPath + @"\SAVEDATA.txt";
        Debug.Log(saveDataPath);

        //�Z�[�u�f�[�^���݂��Ȃ������烍�[�h�{�^����\��
        if (System.IO.File.Exists(saveDataPath) == false)
        {
            loadButton.SetActive(false);
        }
    }

    private void Update()
    {
        if(loadImageIsActive==true)
        {
            loadImage.GetComponent<Image>().enabled = true;
        }
        else
        {
            loadImage.GetComponent<Image>().enabled = false;
        }
    }

    //�Z�[�u
    public async void onClickSaveButton()
    {
        //�Z�[�u�f�[�^�̃t�@�C������������쐬
        if (System.IO.File.Exists(saveDataPath) == false)
        {
            System.IO.File.Create(saveDataPath).Dispose();
        }

        loadImageIsActive = true;

        saveDataBuilder = new StringBuilder();

        saveDataBuilder.Append(await ItemBox.instance.saveSlotItems()); //�X���b�g�A�C�e���̃Z�[�u (whenall�Ŏg���Ȃ��̂�����)

        await UniTask.WhenAll(
            saveObjects(),                    //�I�u�W�F�N�g�̏�Ԃ̃Z�[�u
            saveGimmicksStatus()              //�M�~�b�N�̐i�s�󋵂̃Z�[�u
        );

        
        //�Z�[�u�f�[�^�̏����o��
        using (StreamWriter streamWriter = new StreamWriter(saveDataPath))
        {
            streamWriter.Write(saveDataBuilder.ToString());
            streamWriter.Close();
        }

        loadImageIsActive = false;

        //���C�����j���[��
        SceneManager.LoadScene(0);
    }

    private async UniTask saveObjects()
    {
        // �I�u�W�F�N�g�̏�Ԃ̃Z�[�u

        int ObjectNumber = 0;

        foreach (GameObject objparent in gameObjects)
        {
            Transform[] children = objparent.GetComponentsInChildren<Transform>(true);

            foreach (var obj in children)
            {
                string keyName = obj.name + ObjectNumber;

                if (obj.gameObject.activeSelf)
                {
                    //�\����ԂȂ�1
                    saveDataBuilder.Append(keyName + "%" + 1 +"\n");
                }
                else
                {
                    //��\���Ȃ�2
                    saveDataBuilder.Append(keyName + "%" + 2 + "\n");
                }

                ObjectNumber++;
            }
        }

        await UniTask.SwitchToMainThread();


    }

    private async UniTask saveGimmicksStatus()
    {

        //gimmick�̐i�s�󋵂̃Z�[�u
        foreach (GimmickStatus.Type type in GimmickStatus.Type.GetValues(typeof(GimmickStatus.Type)))
        {
            if (GimmickStatusManager.instance.StatusCheck(type) == true)
            {
                saveDataBuilder.Append(type.ToString() + "%" + 1 + "\n");
            }
            else
            {
                saveDataBuilder.Append(type.ToString() + "%" + 2 + "\n");
            }
        }

        await UniTask.SwitchToMainThread();

    }


    //���[�h
    public async void onClickLoadButton()
    {
        loadImageIsActive = true;

        //�Z�[�u�f�[�^�t�@�C���̓ǂݎ��
        loadDataDictionay = new Dictionary<string, string>();
        string readLine = null;
        using (StreamReader streamReader = new StreamReader(saveDataPath))
        {
            while (true)
            {
                readLine = streamReader.ReadLine();
                if (readLine == null || readLine.Contains("%")==false) break;

                string[] splitWords = readLine.Split("%");          //�Z�[�u�f�[�^��Key�l��Value�l��":"�ŕ������Ă���̂�split�ŕ������Ď擾
                loadDataDictionay.Add(splitWords[0],splitWords[1]);
            }
            streamReader.Close();
        }

        await UniTask.WhenAll
        (
            loadObjects(),       //�I�u�W�F�N�g�̃��[�h
            loadGimmicksStatus() //�M�~�b�N�̐i���󋵂̃��[�h
        );


        //�Q�[���X�^�[�g���̏�����
        StartMenu.instance.GamePlay();

        //�ۑ������A�C�e���̃X���b�g�ւ̔��f
        await ItemBox.instance.LoadSlotItems(loadDataDictionay);

        loadImageIsActive = false;

    }

    private async UniTask loadObjects()
    {
        int ObjectNumber = 0;

        //�I�u�W�F�N�g��S�Ď擾���APlayerPrefs�̕ۑ��ƏƂ炵���킹�ĕ\����ύX����B�P���\���A2����\���B�����l��0�̂܂܂̂��̂ɂ͉������Ȃ�
        foreach (GameObject objparent in gameObjects)
        {
            Transform[] children = objparent.GetComponentsInChildren<Transform>(true);

            foreach (var obj in children)
            {
                string keyName = obj.name + ObjectNumber;

                ObjectNumber++;

                if (keyName.Contains("Camera")==true) continue;

                if (loadDataDictionay.FirstOrDefault(item => item.Key == keyName).Value == "1")
                {
                    obj.gameObject.SetActive(true);
                }
                else if (loadDataDictionay.FirstOrDefault(item => item.Key == keyName).Value == "2")
                {
                    obj.gameObject.SetActive(false);
                }

                
            }

        }

        await UniTask.SwitchToMainThread();

    }

    private async UniTask loadGimmicksStatus()
    {
        //gimmick�̐i�s�󋵂����[�h

        foreach (GimmickStatus.Type type in GimmickStatus.Type.GetValues(typeof(GimmickStatus.Type)))
        {
            if (loadDataDictionay.FirstOrDefault(item => item.Key == type.ToString()).Value == "1")
            {
                GimmickStatusManager.instance.StatusChanger(type);
            }
        }

        await UniTask.SwitchToMainThread();

    }

}
