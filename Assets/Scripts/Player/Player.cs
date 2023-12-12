using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField]
    public CharacterStat playerstats = new CharacterStat();
    JsonLoad json = new JsonLoad();

    private void Awake()
    {
        playerstats = json.LoadPlayerData(playerstats, "PlayerData.json");
    }
}

