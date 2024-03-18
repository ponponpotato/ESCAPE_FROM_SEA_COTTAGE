using UnityEngine;

// 卵の調理と調理後の目玉焼きフライパンを取得する

public class CookEggAndPickUp : MonoBehaviour
{
    [SerializeField] Animator animator = default;

    // 調理用のフライパンをクリックしたときに発動
    public void OnClick()
    {
        if (GimmickStatusManager.instance.cookEggGimmick == false) // 卵の調理が完了していない場合
        {
            Item item = ItemBox.instance.GetSelectedItem();
            if (item.type == Item.Type.Egg)
            {
                ItemBox.instance.ItemUsed();
                animator.Play("EggCook");
                SoundManager.instance.PlaySound(SoundManager.instance.EggCrackSound);
                Invoke("PlayCookSound", 1.0f);
                Invoke("UpdateStatus", 3.5f);
            }
        }
        else // 調理後の目玉焼きフライパン取得
        {
            Item item = ItemDataBase.instance.Spawn(Item.Type.OnDish_Egg);
            ItemBox.instance.SetItem(item);
            SoundManager.instance.PlaySound(SoundManager.instance.PickUpSound);
            gameObject.SetActive(false);
        }


    }

    // 調理音
    void PlayCookSound()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.CookEggSound);
    }

    // ギミックの進捗更新
    void UpdateStatus()
    {
        GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.CookEggGimmick); ;
    }

}
