using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;

    [SerializeField] private Transform respawnPoint;



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) 
            {
            player1.transform.position = respawnPoint.transform.position;
             }

        else if (other.gameObject.CompareTag("Player2")) 
            {
                player2.transform.position = respawnPoint.transform.position;
            }
    }



}
