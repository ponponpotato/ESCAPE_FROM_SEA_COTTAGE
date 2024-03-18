using UnityEngine;

// ���̒����ƒ�����̖ڋʏĂ��t���C�p�����擾����

public class CookEggAndPickUp : MonoBehaviour
{
    [SerializeField] Animator animator = default;

    // �����p�̃t���C�p�����N���b�N�����Ƃ��ɔ���
    public void OnClick()
    {
        if (GimmickStatusManager.instance.cookEggGimmick == false) // ���̒������������Ă��Ȃ��ꍇ
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
        else // ������̖ڋʏĂ��t���C�p���擾
        {
            Item item = ItemDataBase.instance.Spawn(Item.Type.OnDish_Egg);
            ItemBox.instance.SetItem(item);
            SoundManager.instance.PlaySound(SoundManager.instance.PickUpSound);
            gameObject.SetActive(false);
        }


    }

    // ������
    void PlayCookSound()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.CookEggSound);
    }

    // �M�~�b�N�̐i���X�V
    void UpdateStatus()
    {
        GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.CookEggGimmick); ;
    }

}
