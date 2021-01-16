using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHealthScript : MonoBehaviour
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
        hp -= 1;

        if(hp == 2)
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




    
}
