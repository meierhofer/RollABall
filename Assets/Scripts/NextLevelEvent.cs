using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelEvent : MonoBehaviour
{
    void OnTriggerEnter(Collider ChangeScene)
    {
        if (ChangeScene.gameObject.CompareTag("player"))
        {
            SceneManager.LoadScene("PageLevel1"); //2 is the PageNextLevel
        }
    }
}