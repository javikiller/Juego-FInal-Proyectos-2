using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida_Enemigo : MonoBehaviour {

    public GameObject espada;
    public float vidaE = 100;
    public bool muerto = false;

    

    void Update()
    {
        if (vidaE <= 0)
        {
            muerto = true;
        }
        if (vidaE >= 100)
        {
            vidaE = 100;
        }
        if (vidaE < 100 && vidaE > 0)
        {
            vidaE += 1 * Time.deltaTime;
        }
        if (muerto == true)
        {            
            Vida_Player.exp += 100;
            Destroy(this.gameObject);            
        }
        
    }
    void OnTriggerEnter(Collider espada)
    {
        vidaE -= 25;
    }
    
}
