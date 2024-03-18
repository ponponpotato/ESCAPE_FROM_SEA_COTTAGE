using UnityEngine;

// 電気スイッチボックス関連のアニメ

public class SwitchBoxGimmick : MonoBehaviour
{
    // RemoveBoltAnim関連
    [SerializeField] GameObject animatorObj = default;
    [SerializeField] Item.Type type;

    // Switch関連
    [SerializeField] Material material;
    [SerializeField] GameObject SwitchObj = default;
    [SerializeField] GameObject InvisibleItem = default;
    [SerializeField] GameObject HideItem = default;
    bool IsSwitchOn = false;

    private void Update()
    {
        //ロード時対策：すでににスイッチオンギミックが完了していた場合は以下を処理
        if (IsSwitchOn == true) return;
        if (GimmickStatusManager.instance.switchGimmick == true)
        {
            SwitchObj.GetComponent<Renderer>().material = material;
            IsSwitchOn = true;
        }
    }

    // ボックスのボルト除去アニメ
    public void PlayRemoveBoltAnim()
    {
        if (ItemBox.instance.CollectItemSelect(type) == false) return;

        ItemBox.instance.ItemUsed();
        Animator animator = animatorObj.GetComponentInChildren<Animator>();
        animator.Play("RemoveBolt");
        Invoke("StatusUpdate", 2.0f);
        
    }

    // ギミックの進捗更新
    void StatusUpdate()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.UnlockSound);
        GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.RemoveBoltGimmick);
        animatorObj.SetActive(false);
    }


    // 電気のスイッチONのアニメ > ONの場合はシーリングファンが回転しアイテムがドロップ(非表示からアクティブに)する
    public void SwitchOn()
    {
        if (IsSwitchOn == true) return;
        if (GimmickStatusManager.instance.removeBoltGimmick == false) return;

        IsSwitchOn = true;
        SwitchObj.GetComponent<Renderer>().material = material;
        GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.SwitchGimmick);
        SoundManager.instance.PlaySound(SoundManager.instance.SwitchOnSound);
        Invoke("ShowBall", 1.0f);
  
    }

    // アイテムの表示(捧げ玉ピンク)
    void ShowBall()
    {
        HideItem.SetActive(false);
        InvisibleItem.SetActive(true);
        SoundManager.instance.PlaySound(SoundManager.instance.DropBallSound);
    }
}
