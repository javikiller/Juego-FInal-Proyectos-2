using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuxCamaraRanged : MonoBehaviour {

    public GameObject Player;
    public Transform MiraRanged;

    public float inputSensitivity = 150.0f;
    public float clampAngle = 80.0f;

    public float axisX;
    public float axisY;
    public float finalInputX;
    public float finalInputZ;
    public float smoothX;
    public float smoothY;
    private float rotY = 0.0f;
    private float rotX = 0.0f;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.rotation = Quaternion.LookRotation(Player.transform.forward);
        if (!RangeAtack.ranged)
        {

            float inputX = Input.GetAxis("R_XAxis_1");
            //float inputZ = Input.GetAxis("R_YAxis_1");
            axisX = Input.GetAxis("R_XAxis_1");
            //axisY = Input.GetAxis("R_YAxis_1");
            finalInputX = inputX + axisX;
            //finalInputZ = inputZ + axisY;

            rotY += finalInputX * inputSensitivity * Time.deltaTime;


            rotX += finalInputZ * inputSensitivity * Time.deltaTime;

            rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

            Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
            transform.rotation = localRotation;
        }

    }
}
