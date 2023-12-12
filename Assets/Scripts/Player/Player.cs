using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    [SerializeField]
    public CharacterStat player = new CharacterStat();
    JsonLoad json = new JsonLoad();

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


    private void Awake()
    {
        player = json.LoadPlayerData(player, "PlayerData.json");
    }
    void Start()
    {
        StatView();
        FirstViewInit();
    }

    public void StatView()
    {
        Attack.text = player.Attack.ToString();
        Def.text = player.Def.ToString();
        HP.text = player.HP.ToString();
        Cri.text = player.Cri.ToString();

    }
    void Update()
    {
        
    }

    void FirstViewInit() 
    {
        Job.text = player.Job;
        Id.text = player.Id;
        Level.text = "LV . " + player.Level;
        string gold = goldManager.AbbreviateGold(player.Gold);
        Gold.text = gold;
        ExpBar.value = player.Exp / player.MaxExp;
        Exp.text = player.Exp+" / "+player.MaxExp;
    }

    
}

