using UnityEngine;

//バーベキューに関するアニメ、オブジェクトの表示非表示のクラス　

public class BBQAnimPlay : MonoBehaviour
{
    [SerializeField] Animator animator = default;
    [SerializeField] Item.Type type = default;
    [SerializeField] GameObject RowMeetObj = default;
    [SerializeField] GameObject OpenAmiObj = default;
    [SerializeField] GameObject WoodObj = default;
    [SerializeField] GameObject SteakObj = default;

    public string AnimName = "";
    bool IsOpen = false;
    bool CanOpen = false;

    //バーベキューグリルの網をクリックして開閉　アイテムの選択状況に応じて分岐
    public void OnClickObj()
    {

        if (GimmickStatusManager.instance.bbqGimmick == true) return;

        Item item = ItemBox.instance.GetSelectedItem();

        if (item == null)
        {
            Open();
            return;
        }

        switch (item.type)
        {

            case Item.Type.Wood: //薪が選択されていた場合
                CanOpen = true;
                break;

            case Item.Type.Oil: //液体燃料が選択されていた場合
                CanOpen = true;
                break;

            case Item.Type.Meet: //肉が選択が選択されていた場合
                CanOpen = false;
                MeetShow();
                return;

            case Item.Type.Lighter: //ライターが選択されていた場合
                if (AnimPlay() == false)
                {
                    CanOpen = true;
                    break;
                }
                return;

            default:
                CanOpen = true;
                break;

        }

        if (CanOpen == true)
        {
            Open();
        }

    }

    // バーベキューグリルの網の開閉処理
    private void Open()
    {
        if(GimmickStatusManager.instance.bbqGimmick == true) return;
        gameObject.SetActive(false);
        OpenAmiObj.SetActive(true);
    }

    // 肉が選択されていた状態でバーベキューグリルの網をクリックしたら、肉を網にセット
    private void MeetShow()
    {
        ItemBox.instance.ItemUsed();
        RowMeetObj.SetActive(true);
        SoundManager.instance.PlaySound(SoundManager.instance.PickUpSound);
        GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.SetMeetGimmick);
    }

    // バーベキューのアニメ　薪のセット、肉のセット、液体燃料の塗布、ライターの使用すべてを満たす場合に実行
    public bool AnimPlay()
    {
        if (GimmickStatusManager.instance.setWoodGimmick == false) return false;
        if (GimmickStatusManager.instance.setMeetGimmick == false) return false;
        if (GimmickStatusManager.instance.applyOilGimmick == false)
        {
            MessageShow.instance.ShowMessage("ライターのみでは薪に火をつけられそうにない");
            return false;
        }

        animator.Play(AnimName);
        RowMeetObj.SetActive(false);
        WoodObj.SetActive(false);
        SoundManager.instance.PlaySound(SoundManager.instance.BBQSound);
        Invoke("ShowSteak", 3.0f);
        return true;
    }

    // 調理後のステーキ表示
    void ShowSteak()
    {
        SteakObj.SetActive(true);
        GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.BBQGimmick);
    }
}
