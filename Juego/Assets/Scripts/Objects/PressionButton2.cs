using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressionButton2 : MonoBehaviour
{

        
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            ColumnasUp2.up2 = true;
           
        }
        if (coll.tag == "PesoBoton")
        {
            ColumnasUp2.up2= true;
           
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player")
        {
            ColumnasUp2.up2 = false;
            
        }
        if (coll.tag == "PesoBoton")
        {
            ColumnasUp2.up2 = false;
            
        }
    }
}
