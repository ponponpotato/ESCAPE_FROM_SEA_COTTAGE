using UnityEngine;

//�e���r�̃M�~�b�N�N���X

public class TVGimmick : MonoBehaviour
{
    [SerializeField] Material[] NewMaterials = default;
    [SerializeField] GameObject TVLamp = default;
    [SerializeField] Material TVLampMaterial = default;
    public Item.Type type = default;
    public int CurrentIndex = 0;

    private void Start()
    {
        CurrentIndex = 0;
    }

    //�d�r�������Ă����Ԃ̃����R���Ńe���r��ON�A�ȍ~�̓e���r���N���b�N����ƃ`�����l�����؂�ւ��
    public void OnClickThis()
    {
        //�����R���Ƀo�b�e���[�����Ă��邩�̊m�F
        if (ItemBox.instance.CollectItemSelect(type) == true)
        {
            if (GimmickStatusManager.instance.batteryInputGimmick == false)
            {
                MessageShow.instance.ShowMessage("�d�r�������Ă��Ȃ��悤��");
                return;
            }
            ItemBox.instance.ItemUsed();
            GimmickStatusManager.instance.StatusChanger(GimmickStatus.Type.TvSwitchOnGimmick);
        }
        else
        {
            if (GimmickStatusManager.instance.batteryInputGimmick == false) return;
        }

        //�e���r�̓d����ON�i���[�h���Ƀe���r�̓d��ON�̃M�~�b�N���������Ă��鎞�悤�ɂ����Ői���󋵊m�F)
        if (GimmickStatusManager.instance.tvSwitchOnGimmick == false) return;
        TVLamp.GetComponent<Renderer>().material = TVLampMaterial;

        //�N���b�N���ꂽ�񐔂ɉ����ă`�����l���؂�ւ�
        if (CurrentIndex > 3) CurrentIndex = 0;
        gameObject.GetComponent<Renderer>().material = NewMaterials[CurrentIndex];
        CurrentIndex++;
    }

}
