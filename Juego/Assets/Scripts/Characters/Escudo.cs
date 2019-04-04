using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour {

    public BoxCollider col;
    public bool def;
    // Use this for initialization
    void Start()
    {
        col = GetComponent<BoxCollider>();
        def = false;
    }
	// Update is called once per frame
	void Update ()
    {
        if (Movimiento.pj == true)
        {
            ActivarEscudo();
        }

    }
    public void ActivarEscudo()
    {
        if (Input.GetAxis("TriggersR_1") !=0)
        {
            col.isTrigger = true;
            def = true;
        }
        if (Input.GetAxis("TriggersR_1") == 0)
        {
            col.isTrigger = false;
            def = false;
        }
    }
    public void MovimientoDef()
    {

    }
}
