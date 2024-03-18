using UnityEngine;

// d‚É‰t‘Ì”R—¿‚ğ“h•z‚·‚éƒAƒjƒ(d‚ğBBQƒOƒŠƒ‹‚ÉƒZƒbƒg‚·‚é‚Ì‚à‚±‚±‚Ås‚¤)

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
            //d‚ğBBQƒOƒŠƒ‹‚ÉƒZƒbƒg
            case Item.Type.Wood:
                WoodObj_before.SetActive(true);
                ItemBox.instance.ItemUsed();
                GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.SetWoodGimmcik);
                return;

            //d‚É‰t‘Ì”R—¿‚ğ“h•z
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

    // ‰t‘Ì”R—¿“h•z‰¹
    void PlaySound()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.OilApplySound);
    }

    // “h•zŒã‚Ìd(”G‚ê‚½Š´‚¶‚Ì)•\¦‚ÆƒMƒ~ƒbƒN‚Ìi’»XV
    void Wood_AfterShow()
    {
        WoodObj_after.SetActive(true);
        GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.ApplyOilGimmick);
    }
}
