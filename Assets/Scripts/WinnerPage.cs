using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinnerPage : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.ExitPlaymode(); //exits the playmode in the Editor
        Application.Quit();  //exit for the build game
    }
}
