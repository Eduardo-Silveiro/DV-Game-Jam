using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollecter : MonoBehaviour
{
    [SerializeField] private Points scorePoints;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

    public int GetScore()
    {
        return scorePoints.Point;
    }

}
