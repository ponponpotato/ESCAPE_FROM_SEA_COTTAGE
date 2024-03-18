using UnityEngine;

//�}�e���A���̕ύX�N���X

public class MaterialChange : MonoBehaviour
{
    [SerializeField] Material NewMaterial = default;
    public Item.Type type = default;


    //�A�C�e�����g�p���āA�}�e���A����ύX *�����ł̓t�H�g�M�~�b�N�̂�
    public void OnClickThis()
    {
        if (ItemBox.instance.CollectItemSelect(type) == true)
        {
            ItemBox.instance.ItemUsed();
            gameObject.GetComponent<Renderer>().material = NewMaterial;
            GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.PhotoSetGimmick);
        }
    }
}
