using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelEvent : MonoBehaviour
{
    /*void OnTriggerEnter(Collider ChangeScene)
    {
        if (ChangeScene.gameObject.CompareTag("player1") || ChangeScene.gameObject.CompareTag("player2"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //is the PageNextLevel
        }

    }
    */

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player1"))
        {
            Winner.scorePlayer1 += 1;
            Winner.Level1 = "Player 1";
            //UnityEngine.Debug.Log("Player 1 loose");
            //UnityEngine.Debug.Log(string.Format(Winner.Level3));

            EndGame();
        }

        if (other.gameObject.CompareTag("player2"))
        {
            Winner.scorePlayer2 += 1;
            Winner.Level1 = "Player 2";
            //UnityEngine.Debug.Log("Player 2 loose");

            EndGame();
        }


    }
    public void EndGame()
    {

        SceneManager.LoadScene("PageLevel1");
    }
}