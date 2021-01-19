using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTriggerEvent : MonoBehaviour
{
    [SerializeField] private Transform Player1;
    [SerializeField] private Transform Player2;

    [SerializeField] private Transform RespawnPoint;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player1"))
        {
            Player1.transform.position = RespawnPoint.transform.position;
        }

        else if (other.gameObject.CompareTag("player2"))
        {
            Player2.transform.position = RespawnPoint.transform.position;
        }
    }
}
