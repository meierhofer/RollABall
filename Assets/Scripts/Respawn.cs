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
        if(other.gameObject.CompareTag("player1")) 
            {
            player1.transform.position = respawnPoint.transform.position;
            player1.GetComponent<Rigidbody>().velocity = Vector3.zero;

        }

        else if (other.gameObject.CompareTag("player2")) 

        {
            player2.transform.position = respawnPoint.transform.position;
            player2.GetComponent<Rigidbody>().velocity = Vector3.zero;
            
           

            //GetComponent<Rigidbody>().velocity = Vector3.zero; //Get Rigidbody and set velocity to (0f, 0f, 0f)
        }
    }



}
