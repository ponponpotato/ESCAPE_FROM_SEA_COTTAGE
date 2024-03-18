using System;
using UnityEngine;

//アイテムのクラス > 

//[Serializable]はItemDataBaseEntityを使用するうえで必要、using Systemもお忘れなく
[Serializable]
public class Item 
{

    // 列挙型：種類を列挙する　＞　中身入れ替えるとInspectorに影響するので注意
    public enum Type
    {
        InputItem,    //はめ込みアイテム＊４
        Towell,       //タオル
        Key_Green,    //鍵緑
        Driver,       //ドライバー
        RedBall,      //捧げ玉赤
        BlueBall,     //捧げ玉青
        YellowBall,   //捧げ玉黄
        PinkBall,     //捧げ玉ピンク
        Dish_Donut,   //ドーナツ用の皿
        Dish_Egg,     //卵用の皿
        Dish_Meet,    //肉用の皿
        Dish_Fish,    //魚用の皿
        Battery,      //乾電池
        Remocon,      //リモコン
        Photo,        //組み合わせ写真
        Donut,        //ドーナツ
        Rod,          //釣り竿
        ShogiImage,   //追加棋譜
        Knife,        //包丁
        Fish,         //魚
        Soup,         //石鹸
        Egg,          //卵
        PanEgg,       //フライパン
        Scissors,     //ハサミ
        Wood,         //薪
        Lighter,      //ライター
        Meet,         //肉
        OnDish_Donut, //皿に乗ったドーナツ
        OnDish_Egg,   //皿に乗った卵
        OnDish_Meet,  //皿に乗った肉
        OnDish_Fish,  //皿に乗った魚
        Oil,          //液体燃料
        DoorNobu,     //ドアノブ
        Key_Red,      //鍵赤
    }

    //アイテムタイプ
    public Type type;

    //アイテム画像
    public Sprite sprite;

    //アイテムPrefab = アイテムズームした時のオブジェクト（Prefabはギミック時とズーム時で切り分ける)
    public GameObject zoomPrefab;

    //ズーム時に表示させるアイテムの名前
    public string ItemName;

    public Item(Item item)
    {
        this.type = item.type;
        this.sprite = item.sprite;
        this.ItemName = item.ItemName;
    }

    
}
