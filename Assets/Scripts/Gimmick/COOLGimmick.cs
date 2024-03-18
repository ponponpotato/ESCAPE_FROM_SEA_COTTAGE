using UnityEngine;

//タバコCOOLギミックのクラス

public class COOLGimmick : MonoBehaviour
{
    [SerializeField] Animator animator = default;

    public void OnClickObj()
    {
        Item item = ItemBox.instance.GetSelectedItem();
        if (item.type != Item.Type.Lighter) return;//ライター選択してなかったらreturn

        animator.Play("GimmickCool");
        Invoke("Idle", 2.0f);
    }

    void Idle()
    {
        animator.Play("GimmickCool_Idle");
    }

}
