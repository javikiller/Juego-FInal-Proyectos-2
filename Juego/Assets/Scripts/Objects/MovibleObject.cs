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


        touch = false;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        aux = touch;
        
       

        if (touch)
        {

            if (Input.GetButton("B_1"))
            {
                Movimiento2.moovingObject = true;
                rb.transform.position = new Vector3(Front.transform.position.x , rb.transform.position.y, Front.transform.position.z );

            }
          
           

        }
        else
        {

        }
        if (Input.GetButtonUp("B_1"))
        {
            Movimiento2.moovingObject = false;
        }
    }

    public void MoverObjeto()
    {

    }
}
    


