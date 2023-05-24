using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] private static bool paused = true;
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject playerUI; //para puder desligar a UI do player quando tiver saido da pausa
    [SerializeField] private GameObject optionsMenuPanel;
    [SerializeField] private GameObject controlsMenuPanel;


    void Start()
    {
        Time.timeScale = 1f;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsMenuPanel.activeSelf)
            {
                OptionsBack();
            }
            else if (controlsMenuPanel.activeSelf)
            {
                ControlsBack();
            }
            else if (paused)
            {
                PlayGame();
            }
            else
            {
                StopGame();
            }

        }
    }

    public void PlayGame()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        playerUI.SetActive(true);
        AudioListener.pause = false;


    }
    public void StopGame()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        playerUI.SetActive(false);
        AudioListener.pause = true;

    }

    public void Options()
    {
        pauseMenuPanel.SetActive(false);
        optionsMenuPanel.SetActive(true);

    }

    public void OptionsBack()
    {
        pauseMenuPanel.SetActive(true);
        optionsMenuPanel.SetActive(false);
    }

    public void ControlsMenu()
    {
        pauseMenuPanel.SetActive(false);
        controlsMenuPanel.SetActive(true);

    }

    public void ControlsBack()
    {
        pauseMenuPanel.SetActive(true);
        controlsMenuPanel.SetActive(false);
    }


    public void MainMenuComeBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("GameScreen");
    }

  
}