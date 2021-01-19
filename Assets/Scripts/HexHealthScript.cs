using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexHealthScript : MonoBehaviour
{

    public int hp = 3;
    public Material noDamage;
    public Material oneDamage;
    public Material twoDamage;

    public bool isPlayer = true;

    private void Start()
    {
        GetComponent<Renderer>().material = noDamage;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2"))
        {
            DecreaseHealth();
        }
               


    }

    public void DecreaseHealth()
    {
        if( isPlayer == true)
        {
            Wait();
            isPlayer = false;
        }

        hp -= 1;

        if (hp == 2)
        {
            GetComponent<Renderer>().material = oneDamage;

        }

        if (hp == 1)
        {
            GetComponent<Renderer>().material = twoDamage;
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        
    }
    
    
    public void OnCollisionStay(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2"))
        {
            isPlayer = true;
        }
            
        

    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(5);
    }




}
