using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerData player;
    private int maxScore;
    [SerializeField] private GameData gameData;



    // Start is called before the first frame update
    void Start()
    {   
        player.Score = 0;
        player.HighScore = PlayerPrefs.GetInt("MaxScore",0);
        maxScore = PlayerPrefs.GetInt("MaxScore", 0); 
    }

    private void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fruits"))
        {
            
            player.Score += other.gameObject.GetComponent<ItemCollecter>().GetScore();
            other.gameObject.SetActive(false);
            gameData.ActiveFruits--;
            if (player.Score > maxScore)
            {
                maxScore = player.Score;
                player.HighScore = player.Score;
            }
        }
    }


    private void OnDestroy()
    {
        PlayerPrefs.SetInt("MaxScore", maxScore);
        PlayerPrefs.Save(); 
    }

        
        
}
