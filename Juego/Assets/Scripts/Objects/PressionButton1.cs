using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressionButton1 : MonoBehaviour
{

        
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            ColumnasUp1.up1 = true;
           
        }
        if (coll.tag == "PesoBoton")
        {
            ColumnasUp1.up1 = true;
           
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player")
        {
            ColumnasUp1.up1 = false;
            
        }
        if (coll.tag == "PesoBoton")
        {
            ColumnasUp1.up1 = false;
            
        }
    }
}
