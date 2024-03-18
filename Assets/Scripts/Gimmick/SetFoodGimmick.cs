using UnityEngine;

//ランチョンマットに料理をセットするギミックのクラス

public class SetFoodGimmick : MonoBehaviour
{
    [SerializeField] GameObject ShowFoodObj = default;
    [SerializeField] GameObject ShowItemObj = default;
    [SerializeField] GameObject HideObj = default;
    [SerializeField] GameObject HideSlimeObj = default;
    [SerializeField] GameObject SlimeAnimParent = default;
    [SerializeField] GimmickStatus.Type GimmickType = default;
    [SerializeField] Item.Type type = default;
    [SerializeField] Animator animator = default;
    [SerializeField] string animName = default;

    //対応したアイテムの使用に応じてスライムの移動アニメをプレイ
    public void SetFood()
    {
        if (ItemBox.instance.CollectItemSelect(type) == false) return;

        if (HideObj != null) HideObj.SetActive(false);

        ItemBox.instance.ItemUsed();
        ShowFoodObj.SetActive(true);
        SlimeAnimParent.SetActive(true);
        HideSlimeObj.SetActive(false);
        ShowItemObj.SetActive(true);
        GimmickStatusManager.instance.StatusChanger(GimmickType);
        animator.Play(animName);
        Invoke("PlaySound", 0.75f);
        Invoke("PlaySound", 1.75f);
    }

    void PlaySound()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.SlimeMoveSound);
    }
}
