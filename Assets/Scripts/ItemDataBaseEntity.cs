using System.Collections.Generic;
using UnityEngine;

//�e�A�C�e���̉摜��prefab��Inspector��Őݒ肷�邽�߂̃N���X

[CreateAssetMenu]
public class ItemDataBaseEntity : ScriptableObject
{
    public List<Item> items = new List<Item>();

}
