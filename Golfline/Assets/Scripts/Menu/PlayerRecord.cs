using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecord : MonoBehaviour
{
    public List<Player> playerList;
    public string[] levels;
    public Color[] playerColors;

    void OnEnable()
    {
        playerList = new List<Player>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void AddPlayer(string name)
    {
        playerList.Add(new Player(name, playerColors[playerList.Count], levels.Length));
    }
 

    public class Player
    {
        public string name;
        public Color color;
        public int[] putts;

        public Player(string newName, Color newColor, int levelCount)
        {
            name = newName;
            color = newColor;
            putts = new int[levelCount];
        }
    }
}
