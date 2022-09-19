using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecord : MonoBehaviour
{
    public List<Player> playerList;
    public string[] level;
    public Color[] playerColors;
 

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
