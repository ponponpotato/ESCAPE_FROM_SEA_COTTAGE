using UnityEngine;

//InputItem(はめ込みアイテム)を風呂場のボックスにはめ込むクラス

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
                InputItemButtons[i].gameObject.SetActive(true);//InputItemの総量に応じてアクティブ化させる
            }

        }
    }
}
