using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAtack : MonoBehaviour {

    public static bool ranged;
    public GameObject miraRanged;
    public GameObject mira;
    public GameObject camaraPrincipal;
    public GameObject camaraRanged;
    public Rigidbody rb;
    public bool dist = false;

    // Use this for initialization
    void Start ()
    {
        camaraRanged.SetActive(false);
        miraRanged.SetActive(false);
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Movimiento.pj == false)
        {
            RangedVision();
        }
    }

    public void RangedVision()
    {
        if (Input.GetAxis("TriggersL_1") != 0)
        {
            dist = true;
            miraRanged.SetActive(true);
            camaraRanged.SetActive(true);
            ranged = true;

        }
        if (Input.GetAxis("TriggersL_1") == 0)
        {
            dist = false;
            miraRanged.SetActive(false);
            camaraRanged.SetActive(false);
            ranged = false;

        }


    }


}
