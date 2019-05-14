using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnasUp2 : MonoBehaviour {

    public GameObject pilar;
    public static bool up2;
    public bool upAux;
    public float estado = 0;
    public bool activo = false;
    public float contador = 0;
    private Vector3 initialPos;
    void Start()
    {
        upAux = false;
        up2 = false;
        initialPos = transform.position;
    }


    void FixedUpdate()
    {
        if (activo)
        {
            contador += 1 * Time.deltaTime;
            if (contador <= 1)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            }
            
        }
        if (!activo)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z);
            if (transform.position.y <= initialPos.y)
            {
                transform.position = initialPos;
            }
        }
       
        if (!up2)
        {
            contador = 0;
            activo = false;
        }
        ColumnsUp();
    }
    public void ColumnsUp()
    {
        if (up2 && estado == 0)
        {
            activo = true;
            estado = 1;

        }
        if (!up2 && estado == 1)
        {
            activo = false;
            estado = 0;

        }
    }
}
