using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputPlayerName;
    [SerializeField] private PlayerRecord playerRecord;
    [SerializeField] private Button buttonStart;
    [SerializeField] private Button buttonAddPlayer;

   public void ButtonAddPlayer()
    {
        playerRecord.AddPlayer(inputPlayerName.text);
        buttonStart.interactable = true;
        inputPlayerName.text = "";
        if (playerRecord.playerList.Count == playerRecord.playerColors.Length)
        {
            buttonAddPlayer.interactable = false;
        }

    }

    public void ButtonStart()
    {
        SceneManager.LoadScene(playerRecord.levels[0]);
    }
}
