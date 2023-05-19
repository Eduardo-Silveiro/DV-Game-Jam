using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Game Data")]
public class GameData : ScriptableObject
{
    [SerializeField] private int activeFruits;
    

    public int ActiveFruits
    {
        get { return activeFruits; }
        set { activeFruits = value; }
    }
}
