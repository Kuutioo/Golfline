using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private BallController ball;
    [SerializeField] private TextMeshProUGUI labelPlayerName;

    private PlayerRecord playerRecord;
    private int playerIndex;

    void Start()
    {
        playerRecord = GameObject.Find("Player Record").GetComponent<PlayerRecord>();
        playerIndex = 0;
        SetupPlayer();

    }

    private void SetupPlayer()
    {
        ball.SetupBall(playerRecord.playerColors[playerIndex]);
        labelPlayerName.text = playerRecord.playerList[playerIndex].name;
    }

}
