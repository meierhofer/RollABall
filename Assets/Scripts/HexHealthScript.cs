using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexHealthScript : MonoBehaviour
{

    public int hp = 3;
    public Material noDamage;
    public Material oneDamage;
    public Material twoDamage;
    private float waitTime = 0.5f;
    private float timer = 0.0f;

    public bool isPlayer;

    private void Start()
    {
        GetComponent<Renderer>().material = noDamage;
        timer = 0;
        isPlayer = false;
    }

    private void Update()
    {
        if(isPlayer == true)
        {
            timer += Time.deltaTime;
            if(timer >= waitTime)
            {
                DecreaseHealth();
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag("player1") || collision.gameObject.CompareTag("player2"))
        {
            isPlayer = true;
            
            
        }
               


    }

    public void DecreaseHealth()
    {
        /* if( isPlayer == true)
         {
             Wait();
             isPlayer = false;
         }
         */
      
           
            hp -= 1;


            if (hp == 2)
            {
                this.GetComponent<Renderer>().material = oneDamage;

            }

            if (hp == 1)
            {
                this.GetComponent<Renderer>().material = twoDamage;
            }

            if (hp <= 0)
            {
                Destroy(this.gameObject);
            }
            timer = timer - waitTime;
      
        
        
    }
    
    
    
   




}
