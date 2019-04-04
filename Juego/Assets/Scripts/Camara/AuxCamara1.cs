using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuxCamara1 : MonoBehaviour
{

    public float inputSensitivity = 150.0f;
    public float clampAngle = 80.0f;

    public float axisX;
    public float axisY;
    public float finalInputX;
    public float finalInputZ;
    public float smoothX;
    public float smoothY;



    void Start()
    {

    }

    void Update()
    {
        //Giro();
        
        

        //float inputX = Input.GetAxis("L_XAxis_1"); 
        ////float inputZ = Input.GetAxis("R_YAxis_1");
        //axisX = Input.GetAxis("L_XAxis_1");
        ////axisY = Input.GetAxis("R_YAxis_1");
        //finalInputX = inputX + axisX;
        ////finalInputZ = inputZ + axisY;

        //rotY += finalInputX * inputSensitivity * Time.deltaTime;


        //rotX += finalInputZ * inputSensitivity * Time.deltaTime;

        //rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        //Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        //transform.rotation = localRotation;
    }
    public void Giro()
    {
        if (Input.GetAxis("L_YAxis_1") < 0.5f)
        {
            this.gameObject.transform.Rotate(0, Input.GetAxis("L_XAxis_1") * Time.deltaTime, 0);
            Quaternion localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            transform.rotation = localRotation;
        }
        if (Input.GetAxis("L_YAxis_1") > 0.5f)
        {
            this.gameObject.transform.Rotate(0, Input.GetAxis("L_XAxis_1") * Time.deltaTime, 0);
            Quaternion localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            transform.rotation = localRotation;
        }
        if (Input.GetAxis("L_XAxis_1") > 0.5f)
        {
            this.gameObject.transform.Rotate(0, Input.GetAxis("L_XAxis_1") * Time.deltaTime, 0);
            Quaternion localRotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
            transform.rotation = localRotation;
        }
        if (Input.GetAxis("L_XAxis_1") < 0.5f)
        {
            this.gameObject.transform.Rotate(0, Input.GetAxis("L_XAxis_1") * Time.deltaTime, 0);
            Quaternion localRotation = Quaternion.Euler(0.0f, 270f, 0.0f);
            transform.rotation = localRotation;
        }

    }
}
