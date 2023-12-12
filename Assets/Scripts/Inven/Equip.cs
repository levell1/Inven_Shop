using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Equip : MonoBehaviour
{
    public InvenAddItem Inven;
    public Player player;
    public GameObject popup;
    public Image PopupImage;
    public TMP_Text Exp;

    GameObject Clickobject;
    Image image;
    Weapon weapon;
    Armor armor;
    Item selectItem;

    private void Awake()
    {

    }
    // 장비를 장착하는 함수
    public void Equipa(Item item, Image image)
    {
        if (item.IsEquip == true)
        {
            image.color = new Color(238 / 255f, 216 / 255f, 191 / 255f);
            Unequip(item);
            statUpdate(item);
            player.StatView();
        }
        else if (item.IsEquip == false)
        {
            image.color = Color.gray;
            item.IsEquip = true;
            statUpdate(item);
            player.StatView();
        }

    }

    public void Unequip(Item item)
    {
        item.IsEquip = false;
    }
    public void EquipButton() 
    {
        Clickobject = EventSystem.current.currentSelectedGameObject;
        image = Clickobject.GetComponent<Image>();
        
        foreach (var item in Inven.playerInven.items)
        {
            if (Clickobject.name == item.name) 
            {
                selectItem = item;
                //Equipa(item, image);
            }
        }
    }

    public void popupView()
    {
        Clickobject = EventSystem.current.currentSelectedGameObject;
        image = Clickobject.GetComponent<Image>();

        foreach (var item in Inven.playerInven.items)
        {
            if (Clickobject.name == item.name)
            {
                selectItem = item;
            }
        }
        popup.SetActive(true);
        
        //image 세팅, 글자 세팅
        //popupConfirm(Clickobject, selectItem, image);
    }

    public void popupConfirm() 
    {
        Equipa(selectItem, image);
        popup.SetActive(false);
    }


    public void statUpdate(Item item) 
    {
        weapon = item as Weapon;
        armor = item as Armor;
        if (item.IsEquip == true)
        {
            if (item.type == ItemType.Weapon) 
            {
                player.player.Attack += weapon.ItemAttack;
            }
            else if(item.type == ItemType.Armor)
            {
                player.player.Def += armor.ItemDef;
            }
        }
        else if(item.IsEquip == false)
        {
            if (item.type == ItemType.Weapon)
            {
                player.player.Attack -= weapon.ItemAttack;
            }
            else if (item.type == ItemType.Armor)
            {
                player.player.Def -= armor.ItemDef;
            }
        }

    }

}
