using UnityEngine;

//ギミックのステータス管理のクラス
//DictionaryでGimmickStatusクラスで列挙した名前をKeyにしてValueをbool値にすれば、もっとも簡単に書けたはず

public class GimmickStatusManager : MonoBehaviour
{
    public bool tvDrawerGimmick;
    public bool donutBoxGimmick;
    public bool driverBoxGimmick;
    public bool iceBoxGimmick;
    public bool oilGetGimmick;
    public bool shogiGimmick;
    public bool postBoxGimmick;
    public bool doorToiletGimmick;
    public bool setWoodGimmick;
    public bool applyOilGimmick;
    public bool setMeetGimmick;
    public bool bbqGimmick;
    public bool cookEggGimmick;
    public bool batteryInputGimmick;
    public bool greenKeyGimmick;
    public bool redKeyGimmick;
    public bool setRodGimmick;
    public bool removeBoltGimmick;
    public bool switchGimmick;
    public bool setFood_MeetGimmick;
    public bool setFood_EggGimmick;
    public bool setFood_DonutGimmick;
    public bool setFood_FishGimmick;
    public bool setFishGimmick;
    public bool coolGimmick;
    public bool removeDirtGimmick;
    public bool photoSetGimmick;
    public bool pinkBallDeleteGimmick;
    public bool blueBallDeleteGimmick;
    public bool yellowBallDeleteGimmick;
    public bool redBallDeleteGimmick;
    public bool tvSwitchOnGimmick;
    public bool shogiLastSceneGimmick;

    string Hint = "";
    public int GimmickClearCount = 0;

    [SerializeField] Animator animator = default;

    public static GimmickStatusManager instance;

    private void Awake()
    {
        instance = this;
        tvDrawerGimmick = false;
        donutBoxGimmick = false;
        driverBoxGimmick = false;
        iceBoxGimmick = false;
        oilGetGimmick = false;
        shogiGimmick = false;
        postBoxGimmick = false;
        doorToiletGimmick = false;
        setWoodGimmick = false;
        applyOilGimmick = false;
        setMeetGimmick = false;
        bbqGimmick = false;
        cookEggGimmick = false;
        batteryInputGimmick = false;
        greenKeyGimmick = false;
        redKeyGimmick = false;
        setRodGimmick = false;
        removeBoltGimmick = false;
        switchGimmick = false;
        setFood_MeetGimmick = false;
        setFood_EggGimmick = false;
        setFood_DonutGimmick = false;
        setFood_FishGimmick = false;
        setFishGimmick = false;
        coolGimmick = false;
        removeDirtGimmick = false;
        photoSetGimmick = false;
        pinkBallDeleteGimmick = false;
        blueBallDeleteGimmick = false;
        yellowBallDeleteGimmick = false;
        redBallDeleteGimmick = false;
        tvSwitchOnGimmick = false;
        shogiLastSceneGimmick = false;
        Hint = "梯子の汚れをふき取れるものを探そう";
    }

    public void StatusChanger(GimmickStatus.Type type)
    {
        switch (type)
        {
            case GimmickStatus.Type.TVDrawerGimmick:
                tvDrawerGimmick = true;
                break;

            case GimmickStatus.Type.DonutBoxGimmick:
                donutBoxGimmick = true;
                break;

            case GimmickStatus.Type.DriverBoxGimmick:
                driverBoxGimmick = true;
                break;

            case GimmickStatus.Type.IceBoxGimmick:
                iceBoxGimmick = true;
                break;

            case GimmickStatus.Type.OilGetGimmick:
                oilGetGimmick = true;
                break;

            case GimmickStatus.Type.ShogiGimmick:
                shogiGimmick = true;
                break;

            case GimmickStatus.Type.PostBoxGimmick:
                postBoxGimmick = true;
                break;

            case GimmickStatus.Type.DoorToiletGimmick:
                doorToiletGimmick = true;
                break;

            case GimmickStatus.Type.SetWoodGimmcik:
                setWoodGimmick = true;
                break;

            case GimmickStatus.Type.ApplyOilGimmick:
                applyOilGimmick = true;
                break;

            case GimmickStatus.Type.SetMeetGimmick:
                setMeetGimmick = true;
                break;

            case GimmickStatus.Type.BBQGimmick:
                bbqGimmick = true;
                break;

            case GimmickStatus.Type.CookEggGimmick:
                cookEggGimmick = true;
                break;

            case GimmickStatus.Type.BatteryInputGimmick:
                batteryInputGimmick = true;
                break;

            case GimmickStatus.Type.GreenKeyGimmick:
                greenKeyGimmick = true;
                break;

            case GimmickStatus.Type.RedKeyGimmick:
                redKeyGimmick = true;
                break;

            case GimmickStatus.Type.SetRodGimmick:
                setRodGimmick = true;
                break;

            case GimmickStatus.Type.RemoveBoltGimmick:
                removeBoltGimmick = true;
                break;

            case GimmickStatus.Type.SwitchGimmick:
                switchGimmick = true;
                break;

            case GimmickStatus.Type.SetFood_MeetGimmick:
                setFood_MeetGimmick = true;
                break;

            case GimmickStatus.Type.SetFood_EggGimmick:
                setFood_EggGimmick = true;
                break;

            case GimmickStatus.Type.SetFood_DonutGimmick:
                setFood_DonutGimmick = true;
                break;

            case GimmickStatus.Type.SetFood_FishGimmick:
                setFood_FishGimmick = true;
                break;

            case GimmickStatus.Type.SetFishGimmick:
                setFishGimmick = true;
                break;

            case GimmickStatus.Type.CoolGimmick:
                coolGimmick = true;
                break;

            case GimmickStatus.Type.RemoveDirtGimmick:
                removeDirtGimmick = true;
                break;

            case GimmickStatus.Type.PhotoSetGimmick:
                photoSetGimmick = true;
                break;

            case GimmickStatus.Type.PinkBallDeleteGimmck:
                pinkBallDeleteGimmick = true;
                break;

            case GimmickStatus.Type.BlueBallDeleteGimmck:
                blueBallDeleteGimmick = true;
                break;

            case GimmickStatus.Type.YellowBallDeleteGimmck:
                yellowBallDeleteGimmick = true;
                break;

            case GimmickStatus.Type.RedBallDeleteGimmck:
                redBallDeleteGimmick = true;
                break;

            case GimmickStatus.Type.TvSwitchOnGimmick:
                tvSwitchOnGimmick = true;
                break;

            case GimmickStatus.Type.ShogiLastSceneGimmick:
                shogiLastSceneGimmick = true;
                break;
        }

        if (setFood_MeetGimmick == true)
        {
            animator.Play("Fishing_Ready");
        }
    }

    public bool StatusCheck(GimmickStatus.Type type)
    {
        switch (type)
        {
            case GimmickStatus.Type.TVDrawerGimmick:
                return tvDrawerGimmick;

            case GimmickStatus.Type.DonutBoxGimmick:
                return donutBoxGimmick;

            case GimmickStatus.Type.DriverBoxGimmick:
                return driverBoxGimmick;

            case GimmickStatus.Type.IceBoxGimmick:
                return iceBoxGimmick;

            case GimmickStatus.Type.OilGetGimmick:
                return oilGetGimmick;

            case GimmickStatus.Type.ShogiGimmick:
                return shogiGimmick;

            case GimmickStatus.Type.PostBoxGimmick:
                return postBoxGimmick;

            case GimmickStatus.Type.DoorToiletGimmick:
                return doorToiletGimmick;

            case GimmickStatus.Type.SetWoodGimmcik:
                return setWoodGimmick;

            case GimmickStatus.Type.ApplyOilGimmick:
                return applyOilGimmick;

            case GimmickStatus.Type.SetMeetGimmick:
                return setMeetGimmick;

            case GimmickStatus.Type.BBQGimmick:
                return bbqGimmick;

            case GimmickStatus.Type.CookEggGimmick:
                return cookEggGimmick;

            case GimmickStatus.Type.BatteryInputGimmick:
                return batteryInputGimmick;

            case GimmickStatus.Type.GreenKeyGimmick:
                return greenKeyGimmick;

            case GimmickStatus.Type.RedKeyGimmick:
                return redKeyGimmick;

            case GimmickStatus.Type.SetRodGimmick:
                return setRodGimmick;

            case GimmickStatus.Type.RemoveBoltGimmick:
                return removeBoltGimmick;

            case GimmickStatus.Type.SwitchGimmick:
                return switchGimmick;

            case GimmickStatus.Type.SetFood_MeetGimmick:
                return setFood_MeetGimmick;

            case GimmickStatus.Type.SetFood_EggGimmick:
                return setFood_EggGimmick;

            case GimmickStatus.Type.SetFood_DonutGimmick:
                return setFood_DonutGimmick;

            case GimmickStatus.Type.SetFood_FishGimmick:
                return setFood_FishGimmick;

            case GimmickStatus.Type.SetFishGimmick:
                return setFishGimmick;

            case GimmickStatus.Type.CoolGimmick:
                return coolGimmick;

            case GimmickStatus.Type.RemoveDirtGimmick:
                return removeDirtGimmick;

            case GimmickStatus.Type.PhotoSetGimmick:
                return photoSetGimmick;

            case GimmickStatus.Type.PinkBallDeleteGimmck:
                return pinkBallDeleteGimmick;

            case GimmickStatus.Type.BlueBallDeleteGimmck:
                return blueBallDeleteGimmick;

            case GimmickStatus.Type.YellowBallDeleteGimmck:
                return yellowBallDeleteGimmick;

            case GimmickStatus.Type.RedBallDeleteGimmck:
                return redBallDeleteGimmick;

            case GimmickStatus.Type.TvSwitchOnGimmick:
                return tvSwitchOnGimmick;

            case GimmickStatus.Type.ShogiLastSceneGimmick:
                return shogiLastSceneGimmick;


        }
        Debug.Log("ヒットするギミックステータスが存在しません : " + type);
        return false;
    }


    //ヒントのメッセージの管理
    int arraynumber = 1;
    public string currentHintSet()
    {
        if (removeDirtGimmick == false) return "梯子の汚れをふき取れるものを探そう";
        if (greenKeyGimmick == false) return "緑色の鍵を探そう";
        if (driverBoxGimmick == false)
        {
            string[] Hint = new string[2] { "寝室から見える窓と洗濯機の張り紙はテトリスと関係がありそうだ", "本棚の左下にある箱の謎はテトリスと関係している" };
            arraynumber++;
            return Hint[arraynumber % 2];
        }
        if (removeBoltGimmick == false) return "ドライバーを使えるところを探そう";
        if (pinkBallDeleteGimmick == false) return "本棚の青、赤、黄、ピンクの置物から不思議な力を感じる、何かアイテムを使えるかもしれない";
        if (batteryInputGimmick == false) return "リモコンに電池が入っていればテレビの電源を入れられそうだ";
        if (photoSetGimmick == false) return "本棚の写真たての写真は破れている。破れた写真を探してみよう";
        if (tvSwitchOnGimmick == false) return "テレビの電源を入れてみよう";
        if (donutBoxGimmick == false) return "テレビのそれぞれのチャンネルは季節と関係がありそうだ";
        if (shogiLastSceneGimmick == false) return "将棋盤が怪しい";
        if (shogiGimmick == false) return "キッチンの扉にある絵柄は将棋の駒と関係がありそうだ";
        if (donutBoxGimmick == false) return "テレビのそれぞれのチャンネルは季節と関係がありそうだ";
        if (postBoxGimmick == false) return "L字型のテーブルにある4つの灰色のプレートはお風呂場にある箱と関係がありそうだ";
        if (doorToiletGimmick == false) return "ドアノブのない扉にドアノブを取り付けてみよう";
        if (iceBoxGimmick == false) return "掛け軸とトリックアートの絵画は関係がありそうだ";
        if (coolGimmick == false) return "ライターがあれば、ベランダで一服できそうだ";
        if (cookEggGimmick == false) return "卵とフライパンがあれば、目玉焼きが作れそうだ";
        if (setFood_EggGimmick == false) return "4人掛けテーブルのランチョンマットの絵柄に着目しよう";
        if (tvDrawerGimmick == false) return "テレビ台の4つの数字は本棚の本の数と関係してそうだ";
        if (setWoodGimmick == false) return "ベランダにある薪はバーベキューグリルの火種にできそうだ";
        if (oilGetGimmick == false) return "L字型テーブルのボタンは冷蔵庫の中の缶と関係がありそうだ";
        if (applyOilGimmick == false) return "燃料と火をつけるものがあれば薪に火をつけれそうだ";
        if (setMeetGimmick == false) return "バーベキューといえばお肉が欲しいよなあ";
        if (bbqGimmick == false) return "バーベキューをするには食べ物や火種が必要だ";
        if (setFood_MeetGimmick == false) return "4人掛けテーブルのランチョンマットの絵柄に着目しよう";
        if (setFishGimmick == false) return "二回のスタンドに釣り竿をセットしてみよう";
        if (redKeyGimmick == false) return "緑色の鍵を探そう";

        return "ヒントはありません";
    }
    


}
