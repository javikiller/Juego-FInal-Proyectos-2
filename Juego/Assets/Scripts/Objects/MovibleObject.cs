using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovibleObject : MonoBehaviour {

    public GameObject Player;
    public Transform Front;
    public Rigidbody rb;

    public static bool touch = false;
    public bool aux;

	// Use this for initialization
	void Start ()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;

        touch = false;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        aux = touch;
        Vector3 playerPos = Player.transform.position;       
        Vector3 objectPos = Front.transform.position;
       

        if (touch)
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints =  RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;

            if (Input.GetButton("B_1"))
            {
                Movimiento2.moovingObject = true;
                rb.transform.position = objectPos;
                rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;

            }
          
           

        }
        else
        {
            rb.constraints =  RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }
        if (Input.GetButtonUp("B_1"))
        {
            Movimiento2.moovingObject = false;
        }
    }

}
    


