using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;



//ゲームプレイスタート時にアクティブ・非アクティブ化するもの

public class StartMenu : MonoBehaviour
{
    [SerializeField] GameObject StartMenuCanvas = default;
    [SerializeField] GameObject ItemBoxCanvas = default;
    [SerializeField] GameObject CameraCanvas = default;
    [SerializeField] GameObject CameraManager = default;

    public static StartMenu instance;

    //セーブデータの保存先パス
    private string saveDataPath = System.IO.Directory.GetCurrentDirectory() + @"\SAVEDATA.txt";

    //セーブデータが存在するときの続行確認ダイアログのオブジェクト
    [SerializeField] GameObject dialogPanel = default;

    private void Awake()
    {
        instance = this;
    }

    public async void onClickStartButton()
    {
        //セーブデータ存在する場合は、セーブデータ削除してはじめからスタートするか確認
        if(System.IO.File.Exists(saveDataPath)==true)
        {
            dialogPanel.SetActive(true);
            Button[] chidButtons = dialogPanel.GetComponentsInChildren<Button>();
            Button yesButton = chidButtons[0];
            Button noButton = chidButtons[1];

            //「はい」もしくは「いいえ」ボタンが選択されるまで待機
            string result = await yesButton.OnClickAsObservable().Select(_ => "はい")
                        .Merge(
                                noButton.OnClickAsObservable().Select(_ => "いいえ")
                                )
                        .ToUniTask(useFirstValue: true);

            //「はい」ならセーブデータ削除してゲームスタート「いいえ」ならダイアログ非表示
            if (result == "はい")
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
