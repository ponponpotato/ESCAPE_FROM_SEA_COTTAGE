using UnityEngine;

// 薪に液体燃料を塗布するアニメ(薪をBBQグリルにセットするのもここで行う)

public class WoodOilGimmick : MonoBehaviour
{
    [SerializeField] GameObject WoodObj_before = default;
    [SerializeField] GameObject WoodObj_after = default;
    [SerializeField] Animator animator = default;


    public void OnClick()
    {
        Item item = ItemBox.instance.GetSelectedItem();

        if (item == null) return;

        switch (item.type)
        {
            //薪をBBQグリルにセット
            case Item.Type.Wood:
                WoodObj_before.SetActive(true);
                ItemBox.instance.ItemUsed();
                GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.SetWoodGimmcik);
                return;

            //薪に液体燃料を塗布
            case Item.Type.Oil:
                if (GimmickStatusManager.instance.setWoodGimmick  == true)
                {
                    ItemBox.instance.ItemUsed();
                    WoodObj_before.SetActive(false);
                    animator.Play("OilApply");
                    Invoke("PlaySound", 0.5f);
                    Invoke("PlaySound", 1.5f);
                    Invoke("Wood_AfterShow", 2.0f);
                }
                return;
        }
    }

    // 液体燃料塗布音
    void PlaySound()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.OilApplySound);
    }

    // 塗布後の薪(濡れた感じの)表示とギミックの進捗更新
    void Wood_AfterShow()
    {
        WoodObj_after.SetActive(true);
        GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.ApplyOilGimmick);
    }
}
