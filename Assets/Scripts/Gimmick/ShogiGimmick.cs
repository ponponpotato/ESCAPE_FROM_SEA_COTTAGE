using UnityEngine;

//�����̃M�~�b�N�̃N���X

public class ShogiGimmick : MonoBehaviour
{
    [SerializeField] Material material = default;
    public Item.Type type = default;

    bool isNeedUpdate = true;
    private void Update()
    {
        //���[�h���΍�F���łɃM�~�b�N�N���A���Ă���ꍇ�́A�ŏI�Ֆʂɂ��Ă���
        if (isNeedUpdate == false) return;
        if (GimmickStatusManager.instance.shogiLastSceneGimmick == true)
        {
            Material[] materials = gameObject.GetComponent<Renderer>().materials;
            materials[1] = material;
            gameObject.GetComponent<Renderer>().materials = materials;
            isNeedUpdate = false;
        }
    }

    //�ǉ��������擾���Ă�����A�ŏI�Ֆʂ�\��
    public void OnClickThis()
    {
        if (ItemBox.instance.CollectItemSelect(type) == false) return;
        ItemBox.instance.ItemUsed();
        Material[] materials = gameObject.GetComponent<Renderer>().materials;
        materials[1] = material;
        gameObject.GetComponent<Renderer>().materials = materials;
        GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.ShogiLastSceneGimmick);

    }
}
