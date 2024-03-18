using UnityEngine;

//��q�̉���M�~�b�N�̃N���X

public class Dirt : MonoBehaviour
{
    public GameObject Floor2MoveColider;
    [SerializeField] Animator animator = default;
    
    public void Clean()
    {
        if (ItemBox.instance.CollectItemSelect(Item.Type.Towell)==true)//�^�I���I�����ĂȂ������烊�^�[��
        {
            ItemBox.instance.ItemUsed();
            animator.Play("CleanDirt");
            SoundManager.instance.PlaySound(SoundManager.instance.CleanSound);
            Invoke("ColiderON", 1.5f);
            return;
        }
        MessageShow.instance.ShowMessage("���ꂪ�Ђǂ��ēo�ꂻ���ɂȂ�");

    }

    //�A�j���[�V�����I�������ɒ�q�o�邽�߂̃R���C�_�[��ON
    void ColiderON()
    {
        GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.RemoveDirtGimmick);
        Floor2MoveColider.SetActive(true);
        gameObject.SetActive(false);
    }

}
