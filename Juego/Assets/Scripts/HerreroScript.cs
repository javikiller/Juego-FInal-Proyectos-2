using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerreroScript : MonoBehaviour {

    public GameObject canvas;
    public bool contact = false;
	void Start ()
    {
        canvas.SetActive(false);
	}
	
	void Update ()
    {
        if (contact)
        {
            Hablar();
        }
        else
        {
            canvas.SetActive(false);
        }
	}

    public void Hablar()
    {
        canvas.SetActive(true);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            contact = true;
        }
      
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            contact = false;
        }
    }
}
