using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerData player;
    


    // Start is called before the first frame update
    void Start()
    {
        player.Score = 0; 
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fruits"))
        {
            
            player.Score += other.gameObject.GetComponent<ItemCollecter>().getScore();
            Destroy(other.gameObject);
        }
    }

}
