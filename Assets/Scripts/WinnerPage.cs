using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class WinnerPage : MonoBehaviour
{
    public Text winnerIs;

    public void Start()
    {
        if(Winner.scorePlayer1 > Winner.scorePlayer2)
        {
            winnerIs.text = "Player 1";
        }
        //winnerIs.text = Winner.Level3;
        else if(Winner.scorePlayer1 < Winner.scorePlayer2)
        {
            winnerIs.text = "Player 2";
        }
        else if (Winner.scorePlayer1 == Winner.scorePlayer2)
        {
            winnerIs.text = "It's a tie!";
        }
    }

    public void QuitGame()
    {
        Application.Quit();
       // UnityEditor.EditorApplication.ExitPlaymode(); //exits the playmode in the Editor
        Application.Quit();  //exit for the build game
    }
}
