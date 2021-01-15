using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PageLevel1 : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.ExitPlaymode(); //exits the playmode in the Editor
        Application.Quit();  //exit for the build game
    }
}
