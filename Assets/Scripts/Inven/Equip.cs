using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Equip : MonoBehaviour
{
    public InvenAddItem Inven;
    public Player player;
    public GameObject popup;

    public Image PopupImage;

    public TMP_Text Name;
    public TMP_Text Info;
    public TMP_Text ATKorDef;
    public TMP_Text Itemstat;

    GameObject Clickobject;
    Image image;
    Sprite selectimage;
    Weapon weapon;
    Armor armor;
    Item selectItem;

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

    public void popupView()
    {
        Clickobject = EventSystem.current.currentSelectedGameObject;
        image = Clickobject.GetComponent<Image>();
        selectimage = image.transform.GetChild(0).GetComponent<Image>().sprite;

        //selectimage = image.GetComponentsInChildren<Image>()[0];
        /*selectimage = image.GetComponentsInChildren<Image>()[1];
        selectimage = image.GetComponentsInChildren<Image>()[2];*/
        foreach (var item in Inven.playerInven.items)
        {
            if (Clickobject.name == item.name)
            {
                selectItem = item;
            }
        }
        popup.SetActive(true);
        
        PopUpreset(selectItem);

    }

    public void PopUpreset(Item selectItem)
    {
        PopupImage.sprite = selectimage;
        Name.text = selectItem.name;
        Info.text = selectItem.info;

        if (selectItem.type == ItemType.Weapon)
        {
            weapon = selectItem as Weapon;
            ATKorDef.text = "공격력";
            Itemstat.text = weapon.ItemAttack.ToString();
        }
        else if(selectItem.type == ItemType.Armor)
        {
            armor = selectItem as Armor;
            ATKorDef.text = "방어력";
            Itemstat.text = armor.ItemDef.ToString();
        }
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
