using System.Collections;
using System.Collections.Generic;
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
        // 인벤토리에 무기와 방어구 추가
        playerInven.AddItem(Sword); 
        playerInven.AddItem(Ring); 
        playerInven.AddItem(Helmet); 
        playerInven.AddItem(Shoes); 
        playerInven.AddItem(Belt); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
