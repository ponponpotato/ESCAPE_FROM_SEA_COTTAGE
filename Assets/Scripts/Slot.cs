using UnityEngine;
using UnityEngine.UI;

//�X���b�g�̃N���X

public class Slot : MonoBehaviour
{
    [SerializeField] GameObject BackPanel = default;
    [SerializeField] Image image = default ;
    Item item = null;

    private void Start()
    {
        BackPanel.SetActive(false);
    }

    //�摜�̃Z�b�g
    public void SetImage(Item item)
    {
        this.item = item;
        image.sprite = item.sprite;
    }

    //�摜�폜
    public void RemoveImage()
    {
        item = null;
        image.sprite = null;
        OffSelect();
    }

    //Slot�Ɋm�ۂ���Ă���A�C�e����Ԃ�
    public Item GetItem() 
    {
        return item;
    }

    //�X���b�g���󂩂ǂ����̔���
    public bool IsEmpty()
    {
        if (item == null)
        {
            return true;
        }
        return false;
    }

    //�X���b�g�̍��w�i�p�l���\��
    public void OnSelect()
    {
        BackPanel.SetActive(true);
    }

    //�X���b�g�̍��w�i�p�l����\��
    public void OffSelect()
    {
        BackPanel.SetActive(false);
    }

}
