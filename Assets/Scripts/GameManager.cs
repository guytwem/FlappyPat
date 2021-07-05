using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   

    public void Play() // starts the first level
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level_01");
    }

    public void MainMenu() // take the player to main menu scene
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit() // quits application
    {
        Application.Quit();
    }

}
