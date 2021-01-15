using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerPage : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.ExitPlaymode(); //exits the playmode in the Editor
        Application.Quit();  //exit for the build game
    }
}
