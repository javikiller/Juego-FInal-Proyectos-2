using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnasUp : MonoBehaviour {

    public static bool up;
    public bool upAux;
    public float estado = 0;//saber posicion
	// Use this for initialization
	void Start ()
    {
        upAux = false;
        up = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        ColumnsUp();
	}
    public void ColumnsUp()
    {
        if (up && estado ==0)
        {
            estado = 1;
            transform.position = new Vector3(transform.position.x, transform.position.y + 2 , transform.position.z);
        }
        if(!up && estado == 1)
        {
            estado = 0;
            transform.position = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z);

        }

    }
}
