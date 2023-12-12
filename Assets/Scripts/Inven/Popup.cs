using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    GameObject Clickobject;
    Image image;
    Sprite selectimage;
    Item selectItem;

    Weapon weapon;
    Armor armor;

    Equip equip;

    public InvenAddItem Inven;

    public GameObject popup;
    public Image PopupImage;

    public TMP_Text Name;
    public TMP_Text Info;
    public TMP_Text ATKorDef;
    public TMP_Text Itemstat;

    private void Awake()
    {
        equip= GetComponent<Equip>();
    }
    public void popupView()
    {
        Clickobject = EventSystem.current.currentSelectedGameObject;
        image = Clickobject.GetComponent<Image>();                              // 장착 시 색변경을 위한 image
        selectimage = image.transform.GetChild(0).GetComponent<Image>().sprite; // 인벤 장비 클릭시 sprite 값 

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
        else if (selectItem.type == ItemType.Armor)
        {
            armor = selectItem as Armor;
            ATKorDef.text = "방어력";
            Itemstat.text = armor.ItemDef.ToString();
        }
    }

    public void popupConfirm()
    {
        equip.Equipa(selectItem, image);
        popup.SetActive(false);
    }
}
