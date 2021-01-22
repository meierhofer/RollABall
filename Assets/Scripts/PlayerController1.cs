﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour
{
    [SerializeField] private float m_speed = 1f; //speed modifier
    [SerializeField] private Transform respawnPoint;


    private Rigidbody m_playerRigidbody = null; //reference to the players rigidbody

    //private Boolean frozen;

    private float m_movementX, m_movementY; //input vector components

    private int m_collectablesTotalCount, m_collectablesCounter; //everything we need to count the given collectables

    private Stopwatch m_stopwatch; //takes the time
    
    private void Start()
    {
        //frozen = false;
        m_playerRigidbody = GetComponent<Rigidbody>(); //get the rigidbody component

        m_collectablesTotalCount = m_collectablesCounter = GameObject.FindGameObjectsWithTag("Collectable").Length; //find all gameobjects in the scene which are tagged with "Collectable" and count them via Length property 
        
        m_stopwatch = Stopwatch.StartNew(); //start the stopwatch
    }

    private void OnMove(InputValue inputValue)
    {
        Vector2 movementVector = inputValue.Get<Vector2>(); //get the input
       
             //split input vector in its two components
            m_movementX = movementVector.x;
            m_movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(m_movementX, 0f, m_movementY); //translate the 2d vector into a 3d vector

        
        m_playerRigidbody.AddForce(movement * m_speed); //apply a force to the rigidbody

        
        
    }

    

    private void OnTriggerEnter(Collider other)//executed when the player hits another collider (which is set to 'is trigger')
    {
        if (other.gameObject.CompareTag("Collectable"))//has the other gameobject the tag "Collectable"
        {
            other.gameObject.SetActive(false); //set the hit collectable inactive
            GameController.instance.CollectItems1();
            m_collectablesCounter--; //count down the remaining collectables
            if (m_collectablesCounter == 0) //have we found all collectables? if so we won!
            {
                GameController.instance.EndTimer();
                UnityEngine.Debug.Log("YOU WIN!");
                //UnityEngine.Debug.Log($"It took you {m_stopwatch.Elapsed} to find all {m_collectablesTotalCount} collectables.");

#if UNITY_EDITOR //the following code is only included in the unity editor
                //UnityEditor.EditorApplication.ExitPlaymode();//exits the playmode
                Invoke("ShowMenu", 5);



#endif

            }
            else
            {
                UnityEngine.Debug.Log($"You've already found {m_collectablesTotalCount - m_collectablesCounter} of {m_collectablesTotalCount} collectables!");
            }
        }
        else if (other.gameObject.CompareTag("Enemy")) //has the other gameobject the tag "Enemy" / game over state
        {
            //UnityEngine.Debug.Log("GAME OVER!");
            //GameController.instance.ShowGameOverScreen();
            //Invoke("ShowMenu", 2);
            //frozen = true;
            //m_collectablesCounter++;
            //other.gameObject.SetActive(true)
            this.gameObject.transform.position = respawnPoint.transform.position;
            //GetComponent<Rigidbody>().velocity = Vector3.zero; //Get Rigidbody and set velocity to (0f, 0f, 0f)
        


#if UNITY_EDITOR
            //UnityEditor.EditorApplication.ExitPlaymode();


#endif
        }
        /* else if (other.gameObject.CompareTag("Respawn"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero; //Get Rigidbody and set velocity to (0f, 0f, 0f)

        }*/
        else if (other.gameObject.CompareTag("Start"))
        {
            GameController.instance.BeginTimer();
        }
        //else if(other.gameObject.CompareTag("Finish"))
        //{
        //    TimerController.instance.EndTimer();
        //}
    }

  
    

    public void ShowMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
