using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Levels to load")]
    //Load game when press play button
    public string newGameLevel;
    //private string levelToLoad;

    public void PlayButton()
    {
        SceneManager.LoadScene(newGameLevel);
    }

    //Exit game when press the Exit button
    public void ExitButton()
    {
        Application.Quit();
    }
}
