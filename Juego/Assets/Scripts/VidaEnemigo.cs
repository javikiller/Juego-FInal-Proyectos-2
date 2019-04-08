using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    private GameObject enemy;
    public static float vida = 100f;
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
            vida -= 25;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Espada")
        {
            damaged = false;
            vida -= 25;
        }
    }
}
