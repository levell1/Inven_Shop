using UnityEngine;
using UnityEngine.UI;

public class Equip : MonoBehaviour
{
    
    public UiManager Uimanager;

    Weapon weapon;
    Armor armor;

    // 장비를 장착하는 함수
    public void Equipa(Item item, Image image)
    {
        if (item.IsEquip == true)
        {
            image.color = new Color(238 / 255f, 216 / 255f, 191 / 255f);
            Unequip(item);
            statUpdate(item);
            Uimanager.StatView();
        }
        else if (item.IsEquip == false)
        {
            image.color = Color.gray;
            item.IsEquip = true;
            statUpdate(item);
            Uimanager.StatView();
        }
    }

    public void Unequip(Item item)
    {
        item.IsEquip = false;
    }

    public void statUpdate(Item item) 
    {
        weapon = item as Weapon;
        armor = item as Armor;
        if (item.IsEquip == true)
        {
            if (item.type == ItemType.Weapon) 
            {
                Uimanager.playerstats.Attack += weapon.ItemAttack;
            }
            else if(item.type == ItemType.Armor)
            {
                Uimanager.playerstats.Def += armor.ItemDef;
            }
        }
        else if(item.IsEquip == false)
        {
            if (item.type == ItemType.Weapon)
            {
                Uimanager.playerstats.Attack -= weapon.ItemAttack;
            }
            else if (item.type == ItemType.Armor)
            {
                Uimanager.playerstats.Def -= armor.ItemDef;
            }
        }
    }
}
