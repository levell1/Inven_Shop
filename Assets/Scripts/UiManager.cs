using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Player player;
    GoldManager goldManager = new GoldManager();
    public TMP_Text Id;
    public TMP_Text Job;
    public TMP_Text Level;
    public TMP_Text Gold;
    public TMP_Text Exp;
    [SerializeField] private Slider ExpBar;

    public TMP_Text Attack;
    public TMP_Text Def;
    public TMP_Text HP;
    public TMP_Text Cri;

    public InvenAddItem Inventory;
    public TMP_Text InvenCountTxt;

    public CharacterStat playerstats;

    void Start()
    {
        playerstats = player.playerstats;
        StatView();
        FirstViewInit();
        InvenCountView();
    }

    public void StatView()
    {
        Attack.text = playerstats.Attack.ToString();
        Def.text = playerstats.Def.ToString();
        HP.text = playerstats.HP.ToString();
        Cri.text = playerstats.Cri.ToString();
    }

    void FirstViewInit()
    {
        Job.text = playerstats.Job;
        Id.text = playerstats.Id;
        Level.text = "LV. " + playerstats.Level;
        string gold = goldManager.AbbreviateGold(playerstats.Gold);
        Gold.text = gold;
        ExpBar.value = playerstats.Exp / playerstats.MaxExp;
        Exp.text = playerstats.Exp + " / " + playerstats.MaxExp;
    }

    public void InvenCountView() 
    {
        InvenCountTxt.text = Inventory.InvenCount().ToString();
    }
}
