using UnityEngine;

public class InvenAddItem : MonoBehaviour
{
    public PlayerInven playerInven = new PlayerInven();

    public Weapon Sword;
    public Armor Ring;
    public Armor Helmet;
    public Armor Shoes;
    public Armor Belt;
    void Start()
    {
        Sword.IsEquip = false;
        Ring.IsEquip = false;
        Helmet.IsEquip = false;
        Shoes.IsEquip = false;
        Belt.IsEquip = false;

        playerInven.AddItem(Sword); 
        playerInven.AddItem(Ring); 
        playerInven.AddItem(Helmet); 
        playerInven.AddItem(Shoes); 
        playerInven.AddItem(Belt); 
    }
}
