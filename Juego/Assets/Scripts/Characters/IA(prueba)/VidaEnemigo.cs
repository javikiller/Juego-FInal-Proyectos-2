using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaELento : MonoBehaviour
{
    private GameObject enemy;
    public static float vida = 200f;
    public static bool alaif = true;
    public static bool damaged = false;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            alaif = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Espada")
        {
            damaged = true;
            vida -= 20;
        }
        if (other.tag == "Espada2")
        {
            damaged = true;
            vida -= 35;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Espada")
        {
            damaged = false;
            
        }
        if (other.tag == "Espada2")
        {
            damaged = false;
            
        }
    }
}
