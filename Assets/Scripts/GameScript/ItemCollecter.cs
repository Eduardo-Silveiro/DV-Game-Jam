using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollecter : MonoBehaviour
{
    [SerializeField] private Points scorePoints;
   
    public int GetScore()
    {
        return scorePoints.Point;
    }

}
