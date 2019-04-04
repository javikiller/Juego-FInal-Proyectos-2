using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject player;      
    public bool muerto = false;

    void Update()
    {       
        
    }
    void OnTriggerEnter(Collider player)
    {
        Vida_Player.arco = true;
        Destroy(this.gameObject);        
    }

}
