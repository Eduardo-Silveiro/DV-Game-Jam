using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Game Data")]
public class GameData : ScriptableObject
{
    [SerializeField] private int activeFruits;
    [SerializeField] private bool changeSceen;
    [SerializeField] private bool isDead;


    public int ActiveFruits
    {
        get { return activeFruits; }
        set { activeFruits = value; }
    }
    public bool ChangeSceen
    {
        get { return changeSceen; }
        set { changeSceen = value; }
    }
    public bool ISDead
    {
        get { return isDead; }
        set { isDead = value; }
    }

}
