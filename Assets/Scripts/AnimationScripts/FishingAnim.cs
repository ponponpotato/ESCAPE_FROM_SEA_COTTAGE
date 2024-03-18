using UnityEngine;

// 釣りのアニメ

public class FishingAnim : MonoBehaviour
{

    [SerializeField] GameObject ShowObj_rod;
    [SerializeField] GameObject ShowObj_fish;
    [SerializeField] Animator animator;

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
    }

}
