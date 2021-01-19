using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level3Winner : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2"))
        {
            EndGame();
        }



    }
    public void EndGame()
    {
        SceneManager.LoadScene("WinnerPage");
    }
    
}
