using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   [SerializeField] private Transform pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenu.gameObject.activeSelf)
            {
                BtnContinue();
            }
            else
            {
                pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
                AudioListener.pause = true;
            }
        }
    }


    public void BtnContinue()
    {
        
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
        
    }

    public void BtnMenuGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void BtnExit()
    {
        Application.Quit();
    }

    public void BtnRetry()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

}
