using System;
using UnityEngine;

//�A�C�e���̃N���X > 

//[Serializable]��ItemDataBaseEntity���g�p���邤���ŕK�v�Ausing System�����Y��Ȃ�
[Serializable]
public class Item 
{

    // �񋓌^�F��ނ�񋓂���@���@���g����ւ����Inspector�ɉe������̂Œ���
    public enum Type
    {
        InputItem,    //�͂ߍ��݃A�C�e�����S
        Towell,       //�^�I��
        Key_Green,    //����
        Driver,       //�h���C�o�[
        RedBall,      //�����ʐ�
        BlueBall,     //�����ʐ�
        YellowBall,   //�����ʉ�
        PinkBall,     //�����ʃs���N
        Dish_Donut,   //�h�[�i�c�p�̎M
        Dish_Egg,     //���p�̎M
        Dish_Meet,    //���p�̎M
        Dish_Fish,    //���p�̎M
        Battery,      //���d�r
        Remocon,      //�����R��
        Photo,        //�g�ݍ��킹�ʐ^
        Donut,        //�h�[�i�c
        Rod,          //�ނ��
        ShogiImage,   //�ǉ�����
        Knife,        //�
        Fish,         //��
        Soup,         //�Ό�
        Egg,          //��
        PanEgg,       //�t���C�p��
        Scissors,     //�n�T�~
        Wood,         //�d
        Lighter,      //���C�^�[
        Meet,         //��
        OnDish_Donut, //�M�ɏ�����h�[�i�c
        OnDish_Egg,   //�M�ɏ������
        OnDish_Meet,  //�M�ɏ������
        OnDish_Fish,  //�M�ɏ������
        Oil,          //�t�̔R��
        DoorNobu,     //�h�A�m�u
        Key_Red,      //����
    }

    //�A�C�e���^�C�v
    public Type type;

    //�A�C�e���摜
    public Sprite sprite;

    //�A�C�e��Prefab = �A�C�e���Y�[���������̃I�u�W�F�N�g�iPrefab�̓M�~�b�N���ƃY�[�����Ő؂蕪����)
    public GameObject zoomPrefab;

    //�Y�[�����ɕ\��������A�C�e���̖��O
    public string ItemName;

    public Item(Item item)
    {
        this.type = item.type;
        this.sprite = item.sprite;
        this.ItemName = item.ItemName;
    }

    
}
