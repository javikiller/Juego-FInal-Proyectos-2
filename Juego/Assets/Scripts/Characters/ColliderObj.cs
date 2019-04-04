using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderObj : MonoBehaviour {

    public GameObject caja;
    public bool touch;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerStay(Collider caja)
    {
        touch = true;
    }

    public void MoverCaja()
    {
        if (touch)
        {

        }
    }
}
