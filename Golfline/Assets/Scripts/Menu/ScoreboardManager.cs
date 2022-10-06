using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreboardManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText, scoreText;

    private PlayerRecord playerRecord;
    
    void Start()
    {
        playerRecord = GameObject.Find("Player Record").GetComponent<PlayerRecord>();
        nameText.text = "";
        scoreText.text = "";
        foreach (var player in playerRecord.GetScoreboardList())
        {
            nameText.text += player.name + "\n";
            scoreText.text += player.totalStrokes + "\n";
        }
    }

    void Update()
    {
        scoreText.fontSize = nameText.fontSize;
    }

    public void ButtonReturnMenu()
    {
        Destroy(playerRecord.gameObject);
        SceneManager.LoadScene("Menu");
    }
}
