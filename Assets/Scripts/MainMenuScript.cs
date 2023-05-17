using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void btnNewGame()
    {
        SceneManager.LoadScene("Game");
    }


    public void btnScore()
    {
        SceneManager.LoadScene("");
    }


    public void btnQuit()
    {
        Application.Quit();
    }
}
