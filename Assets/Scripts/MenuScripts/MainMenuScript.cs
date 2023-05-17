using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void BtnNewGame()
    {
        SceneManager.LoadScene("Game");
    }


    public void BtnScore()
    {
        SceneManager.LoadScene("");
    }


    public void BtnQuit()
    {
        Application.Quit();
    }
    public void BtnGameContext() {
        SceneManager.LoadScene("GameContext");
    }
}
