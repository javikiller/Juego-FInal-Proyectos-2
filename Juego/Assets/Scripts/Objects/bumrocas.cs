using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumrocas : MonoBehaviour {

    private Rigidbody rb;   
    private SphereCollider col;

    // Use this for initialization
    void Start ()
    {        
        rb = this.gameObject.GetComponent<Rigidbody>();
        col = this.gameObject.GetComponent<SphereCollider>();
        rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
        col.isTrigger = true;
    }

    // Update is called once per frame
    void Update ()
    {
        if (bumboton.activo)
        {
            rb.constraints = RigidbodyConstraints.None;
            col.isTrigger = false;
        }
    }
}
