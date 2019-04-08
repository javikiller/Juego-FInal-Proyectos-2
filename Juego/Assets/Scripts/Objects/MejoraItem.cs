using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejoraItem : MonoBehaviour {

    public GameObject mejora;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        mejora.transform.Rotate(new Vector3(0, 0, 2));
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Movimiento.mejora = true;
            mejora.SetActive(false);
        }
    }
}
