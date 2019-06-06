using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnasUp1 : MonoBehaviour {

    public GameObject pilar;
    public static bool up1;
    public bool upAux;
    public float estado = 0;
    public bool activo = false;
    public float contador = 0;
    private Vector3 initialPos;
	void Start ()
    {
        upAux = false;
        up1 = false;
        initialPos = transform.position;
	}
	
	
	void FixedUpdate ()
    {
        if (PressionButton1.activo)
        {
            contador += 1 * Time.deltaTime;
            if (contador <= 1)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.45f, transform.position.z);
            }
            if(contador >= 2)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z);
            }
            if(transform.position.y <= initialPos.y)
            {
                transform.position = initialPos;
            }
        }
        if (!PressionButton1.activo)
        {
            transform.position = initialPos;
            
        }
        if(contador >= 4)
        {
            contador = 0;
        }
        
        ColumnsUp();
	}
    public void ColumnsUp()
    {
        if (PressionButton1.activo && estado == 0)
        {
            activo = true;
        }
    }
}
