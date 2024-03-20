using UnityEngine;

// 釣りのアニメ

public class FishingAnim : MonoBehaviour
{

    [SerializeField] GameObject ShowObj_rod;
    [SerializeField] GameObject ShowObj_fish;
    [SerializeField] Animator animator;

    //魚が釣れる状態（ステーキを皿にのせるギミッククリア）になっていたら、釣り竿が揺れるアニメーションを一度だけ再生
    bool isAnimActive = false;
    private void Update()
    {
        if (GimmickStatusManager.instance.StatusCheck(GimmickStatus.Type.SetFood_MeetGimmick) == true && isAnimActive == false)
        {
            animator.Play("Fishing_Ready");
            isAnimActive = true;
        }
    }

    // ステーキをランチョンマットにセーブするギミックが完了している場合に実行可能
    public void PlayFishingAnim()
    {
        if (GimmickStatusManager.instance.setFood_MeetGimmick == true)
        {
            animator.Play("Fishing");
            SoundManager.instance.PlaySound(SoundManager.instance.FishingSound);
            Invoke("ShowItem", 0.75f);
        }
    }

    // 釣った後は、寝かせた釣り竿とバケツに入った魚表示
    void ShowItem()
    {
        gameObject.SetActive(false);
        ShowObj_rod.SetActive(true);
        ShowObj_fish.SetActive(true);
        GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.FishingGimmick);
    }

}
