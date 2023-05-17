using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private int score;

    public int Score
    {
        get { return score; }
        set { score = value; }
    }
}
