using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WinScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: "+playerData.Score;
        highScoreText.text = "High Score: " + playerData.HighScore;
    }

}
