using UnityEngine;

//InputItem(�͂ߍ��݃A�C�e��)�𕗘C��̃{�b�N�X�ɂ͂ߍ��ރN���X

public class InputItemInput : MonoBehaviour
{
    [SerializeField] GameObject[] InputItemButtons;

    int TotalItemCount = 0;

    public void Input()
    {
        if (ItemBox.instance.CollectItemSelect(Item.Type.InputItem) == true)
        {
            TotalItemCount = ItemBox.instance.InputItemTotalCount;
            ItemBox.instance.ItemUsed();
            for(int i = 0 ; i < TotalItemCount; i++)
            {
                InputItemButtons[i].gameObject.SetActive(true);//InputItem�̑��ʂɉ����ăA�N�e�B�u��������
            }

        }
    }
}
