using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressionButton1 : MonoBehaviour
{
    public static bool activo = false;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            activo = true;
        }
    }
}
