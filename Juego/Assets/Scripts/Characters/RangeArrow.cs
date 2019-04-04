using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeArrow : MonoBehaviour {

    public Camera cameraRanged;
    public GameObject Arrow;

    public float contador = 0f; 
    // Use this for initialization
    void Start ()
    {

        contador = 0;
    }

    // Update is called once per frame
    void Update ()
    {
        Atack();
	}
    public void Atack()
    {
        if (RangeAtack.ranged)
        {
            if (Input.GetAxis("TriggersR_1")!=0)
            {
                contador += 1 * 0.015f;

                
            }
            
            if (Input.GetAxis("TriggersR_1") == 0 && contador > 3)
            {
                GameObject newArrow = Instantiate(Arrow) as GameObject;
                newArrow.transform.position = transform.position;
                Rigidbody ArrowRb = newArrow.GetComponent<Rigidbody>();
                ArrowRb.velocity = cameraRanged.transform.forward * 30;
                contador = 0;

            }
            if (Input.GetAxis("TriggersR_1") == 0)
            {
                
                contador = 0;

            }
        }

    }
}
