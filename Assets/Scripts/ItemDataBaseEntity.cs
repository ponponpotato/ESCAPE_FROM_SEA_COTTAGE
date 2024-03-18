using System.Collections.Generic;
using UnityEngine;

//各アイテムの画像やprefabをInspector上で設定するためのクラス

[CreateAssetMenu]
public class ItemDataBaseEntity : ScriptableObject
{
    public List<Item> items = new List<Item>();

}
