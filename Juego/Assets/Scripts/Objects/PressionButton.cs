using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressionButton : MonoBehaviour
{

        
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            ColumnasUp.up = true;
           
        }
        if (coll.tag == "PesoBoton")
        {
            ColumnasUp.up = true;
           
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player")
        {
            ColumnasUp.up = false;
            
        }
        if (coll.tag == "PesoBoton")
        {
            ColumnasUp.up = false;
            
        }
    }
}
