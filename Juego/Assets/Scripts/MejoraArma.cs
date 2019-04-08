using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejoraArma : MonoBehaviour {

    public GameObject mehSword;
    public GameObject betterSword;
	void Start ()
    {
        mehSword.SetActive(true);
        betterSword.SetActive(false);
    }
	
	void Update ()
    {
		
	}

    public void Upgrade()
    {
        if (Movimiento.mejora)
        {
            mehSword.SetActive(false);
            betterSword.SetActive(true);
        }
        
    }
}
