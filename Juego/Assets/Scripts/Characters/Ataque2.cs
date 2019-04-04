using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque2 : MonoBehaviour
{

    public GameObject coll;
    public float tiempo = 0;
    bool atacando = false;
    public bool arma = false;

    void Start()
    {
        coll.SetActive(false);
    }

    void Update()
    {
        if (Movimiento.pj == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                atacando = true;

            }
            if (atacando && arma == false)
            {
                coll.SetActive(true);

                tiempo += 2f * Time.deltaTime;
            }
            if (!atacando && tiempo > 0)
            {
                coll.SetActive(false);

                tiempo -= 2f * Time.deltaTime;
            }
            if (tiempo >= 1)
            {
                atacando = false;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                arma = true;
            }
            if (arma == true)
            {

            }
        }
        
    }
}
