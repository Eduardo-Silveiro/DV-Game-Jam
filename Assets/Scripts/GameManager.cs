using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI HighScoreText;
    [SerializeField] private PlayerData player;
    [SerializeField] private GameData gameData;
    private bool hasPlayed;
    [SerializeField] private AudioSource playerDeathSound;


    private void Start()
    {
        hasPlayed = false;
    }
    void Update()
    {
        if (gameData.ISDead==true && hasPlayed == false) { 

            hasPlayed=true;
            playerDeathSound.Play();

        }
        if (gameData.ChangeSceen == true)
        {
            Debug.Log(gameData.ChangeSceen);
            SceneManager.LoadScene("GameOverScreen");
        }

        ScoreText.text = "Score: " + player.Score;
        HighScoreText.text = "HighScore: " + player.HighScore;
    }




    

}
