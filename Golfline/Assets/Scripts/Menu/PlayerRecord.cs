using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        playerList.Add(new Player(name, playerColors[playerList.Count], levels.Length));
    }

    public void AddStrokes(int playerIndex, int StrokeCount)
    {
        playerList[playerIndex].strokes[levelIndex] = StrokeCount;
    }
 

    public class Player
    {
        public string name;
        public Color color;
        public int[] strokes;

        public Player(string newName, Color newColor, int levelCount)
        {
            name = newName;
            color = newColor;
            strokes = new int[levelCount];
        }
    }
}
