using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;


public class Level3Winner : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player1"))
        {
            Winner.scorePlayer2 += 1;
            Winner.Level3 = "Player 2";
            //UnityEngine.Debug.Log("Player 1 loose");
            //UnityEngine.Debug.Log(string.Format(Winner.Level3));

            EndGame();
        }

        if(collision.gameObject.CompareTag("player2"))
        {
            Winner.scorePlayer1 += 1;
            Winner.Level3 = "Player 1";
            //UnityEngine.Debug.Log("Player 2 loose");

            EndGame();
        }


    }
    public void EndGame()
    {
        
        SceneManager.LoadScene("WinnerPage");
    }
    
}
