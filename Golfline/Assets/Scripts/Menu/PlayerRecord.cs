using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerRecord : MonoBehaviour
{
    public List<Player> playerList;
    public string[] levels;
    public Color[] playerColors;
    public int levelIndex;

    void OnEnable()
    {
        playerList = new List<Player>();
        DontDestroyOnLoad(gameObject);
    }

    public void AddPlayer(string name)
    {
        playerList.Add(new Player(name, playerColors[playerList.Count]));
    }

    public void AddStrokes(int playerIndex, int strokeCount)
    {
        playerList[playerIndex].totalStrokes += strokeCount;
        playerList[playerIndex].currentStrokes = 0;
    }

    public void ResetList()
    {
        playerList = null;
    }

    public List<Player> GetScoreboardList()
    {
        return (from p in playerList orderby p.totalStrokes select p).ToList();
    }
 

    public class Player
    {
        public string name;
        public Color color;
        public int currentStrokes;
        public int totalStrokes;

        public Player(string newName, Color newColor)
        {
            name = newName;
            color = newColor;
            currentStrokes = 0;
        }
    }
}
