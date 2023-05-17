using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Points", menuName = "Points Prefab")]
public class Points : ScriptableObject
{
    [SerializeField]private int points;

    public int Point
    {
        get { return points; }
        set { points = value; }
    }
}
