using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour {

    public GameObject coll;
    public float tiempo = 0 ;
    public bool atacando = false;    
    public bool arma = false;
    
	void Start ()
    {
        coll.SetActive(false);
	}	
	void Update ()
    {        
        Mov();
        Cont();       
    }
    public void Mov()
    {
        if (Movimiento.pj == false)
        {
            if (Input.GetButtonDown("X_1") && atacando == false)
            {
                atacando = true;  
            }
            if (atacando && arma == false)
            {
                coll.SetActive(true);
                tiempo += 1f * Time.deltaTime;
            }         
            if (Input.GetKeyDown(KeyCode.Q))
            {
                arma = true;
            }           
        }
    }
    public void Cont()
    {
        if (!atacando && tiempo > 0)
        {
            coll.SetActive(false);

            tiempo = 0;
        }
        if (tiempo >= 1)
        {
            atacando = false;
        }
    }    
}   
