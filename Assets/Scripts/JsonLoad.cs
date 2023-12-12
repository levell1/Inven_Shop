using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonLoad
{
    public void SavePlayerData(CharacterStat player)
    {
        string jsonData = JsonUtility.ToJson(player, true);
        string path = Path.Combine(Application.dataPath, "PlayerData.json");
        File.WriteAllText(path, jsonData);
    }
    public CharacterStat LoadPlayerData(CharacterStat player, string json)
    {
        string path = Path.Combine(Application.dataPath, json);
        string jsonData = File.ReadAllText(path);
        player = JsonUtility.FromJson<CharacterStat>(jsonData);
        return player;
    }
}
