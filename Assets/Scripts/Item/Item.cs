using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    None,
    Weapon,
    Armor
}

[CreateAssetMenu(fileName = "Item", menuName = "Items/Default", order = 0)]
public class Item : ScriptableObject
{
    public ItemType type = 0;
    public string Name;
    public string info;
    public int ItemGold;
    public bool IsEquip = false;
}