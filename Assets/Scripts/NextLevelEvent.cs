using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelEvent : MonoBehaviour
{
    void OnTriggerEnter(Collider ChangeScene)
    {
        if (ChangeScene.gameObject.CompareTag("player1") || ChangeScene.gameObject.CompareTag("player2"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //is the PageNextLevel
        }
    }
}