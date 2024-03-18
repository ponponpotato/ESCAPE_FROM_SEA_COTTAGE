using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//セーブとロードクラス

public class SaveLoadData : MonoBehaviour
{
    //セーブするオブジェクトのリスト
    public List<GameObject> gameObjects;

    //セーブ・ロード中の画像オブジェクト
    public GameObject loadImage = default;

    //ロードボタンオブジェクト
    public GameObject loadButton = default;

    //セーブデータの保存先パス
    private string saveDataPath = System.IO.Directory.GetCurrentDirectory() + @"\SAVEDATA.txt";

    //セーブデータをstringBuilderで作成 stringより高速
    private StringBuilder saveDataBuilder;

    //ロードデータをDictionaryで確保
    private Dictionary<string, string> loadDataDictionay;


    bool loadImageIsActive = false;

    private void Start()
    {
        //セーブデータ存在しなかったらロードボタン非表示
        if(System.IO.File.Exists(saveDataPath) == false)
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

    //セーブ
    public async void onClickSaveButton()
    {
        //セーブデータのファイル無かったら作成
        if (System.IO.File.Exists(saveDataPath) == false)
        {
            System.IO.File.Create(saveDataPath).Dispose();
        }

        loadImageIsActive = true;

        saveDataBuilder = new StringBuilder();

        saveDataBuilder.Append(await ItemBox.instance.saveSlotItems()); //スロットアイテムのセーブ (whenallで使えないのここで)

        await UniTask.WhenAll(
            saveObjects(),                    //オブジェクトの状態のセーブ
            saveGimmicksStatus()              //ギミックの進行状況のセーブ
        );

        
        //セーブデータの書き出し
        using (StreamWriter streamWriter = new StreamWriter(saveDataPath))
        {
            streamWriter.Write(saveDataBuilder.ToString());
            streamWriter.Close();
        }

        //loadImage.GetComponent<Image>().enabled = false;
        loadImageIsActive = false;

        //メインメニューへ
        SceneManager.LoadScene(0);
    }

    private async UniTask saveObjects()
    {
        // オブジェクトの状態のセーブ

        int ObjectNumber = 0;

        foreach (GameObject objparent in gameObjects)
        {
            Transform[] children = objparent.GetComponentsInChildren<Transform>(true);

            foreach (var obj in children)
            {
                string keyName = obj.name + ObjectNumber;

                if (obj.gameObject.activeSelf)
                {
                    //表示状態なら1
                    saveDataBuilder.Append(keyName + "%" + 1 +"\n");
                    //PlayerPrefs.SetInt(keyName, 1);
                    //Debug.Log($"{keyName}が" + PlayerPrefs.GetInt(keyName) + "で保存された");
                }
                else
                {
                    //非表示なら2
                    saveDataBuilder.Append(keyName + "%" + 2 + "\n");
                    //PlayerPrefs.SetInt(keyName, 2);
                    //Debug.Log($"{keyName}が" + PlayerPrefs.GetInt(keyName) + "で保存された");
                }

                ObjectNumber++;
            }
        }

    }

    private async UniTask saveGimmicksStatus()
    {
        //await UniTask.SwitchToThreadPool();

        //gimmickの進行状況のセーブ
        foreach (GimmickStatus.Type type in GimmickStatus.Type.GetValues(typeof(GimmickStatus.Type)))
        {
            if (GimmickStatusManager.instance.StatusCheck(type) == true)
            {
                //PlayerPrefs.SetInt(type.ToString(), 1);
                saveDataBuilder.Append(type.ToString() + "%" + 1 + "\n");
                //Debug.Log($"{type.ToString()}が" + PlayerPrefs.GetInt(type.ToString()) + "で保存された");
            }
            else
            {
                //PlayerPrefs.SetInt(type.ToString(), 2);
                saveDataBuilder.Append(type.ToString() + "%" + 2 + "\n");
                //Debug.Log($"{type.ToString()}が" + PlayerPrefs.GetInt(type.ToString()) + "で保存された");
            }
        }

        await UniTask.SwitchToMainThread();

    }


    //ロード
    public async void onClickLoadButton()
    {
        //loadImage.GetComponent<Image>().enabled = true;
        await UniTask.SwitchToThreadPool();
        loadImageIsActive = true;
        await UniTask.SwitchToMainThread();

        //セーブデータファイルの読み取り
        loadDataDictionay = new Dictionary<string, string>();
        string readLine = null;
        using (StreamReader streamReader = new StreamReader(saveDataPath))
        {
            while (true)
            {
                readLine = streamReader.ReadLine();
                if (readLine == null || readLine.Contains("%")==false) break;

                string[] splitWords = readLine.Split("%");          //セーブデータはKey値とValue値が":"で分けられているのでsplitで分割して取得
                loadDataDictionay.Add(splitWords[0],splitWords[1]);
            }
            streamReader.Close();
        }

        await UniTask.WhenAll
        (
            loadObjects(),       //オブジェクトのロード
            loadGimmicksStatus() //ギミックの進捗状況のロード
        );


        //ゲームスタート時の初期化
        StartMenu.instance.GamePlay();

        //保存したアイテムのスロットへの反映
        await ItemBox.instance.LoadSlotItems(loadDataDictionay);

        //loadImage.GetComponent<Image>().enabled = false;
        loadImageIsActive = false;

    }

    private async UniTask loadObjects()
    {
        int ObjectNumber = 0;

        await UniTask.SwitchToMainThread();

        //オブジェクトを全て取得し、PlayerPrefsの保存と照らし合わせて表示を変更する。１が表示、2が非表示。初期値の0のままのものには何もしない
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

    }

    private async UniTask loadGimmicksStatus()
    {
        //gimmickの進行状況をロード

        await UniTask.SwitchToMainThread();

        foreach (GimmickStatus.Type type in GimmickStatus.Type.GetValues(typeof(GimmickStatus.Type)))
        {
            if (loadDataDictionay.FirstOrDefault(item => item.Key == type.ToString()).Value == "1")
            {
                GimmickStatusManager.instance.StatusChanger(type);
            }
        }

    }

}
