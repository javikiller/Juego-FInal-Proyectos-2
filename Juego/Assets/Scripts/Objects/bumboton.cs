using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumboton : MonoBehaviour {

    public static bool activo;

	// Use this for initialization
	void Start () {
        activo = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            activo = true;
        }
    }
}
