using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float CameraMoveSpeed = 120.0f;
    public GameObject CameraFollowObj;
    public static GameObject CameraFollowObjAux;
    Vector3 FollowPOS;
    public float clampAngle = 80.0f;
    public float inputSensitivity = 150.0f;
    
    public float camDistanceXToPlayer;
    public float camDistanceYToPlayer;
    public float camDistanceZToPlayer;
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
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        CameraFollowObjAux = CameraFollowObj;



    }
	
	void Update ()
    {

        CameraFollowObj = CameraFollowObjAux;
        if (!RangeAtack.ranged)
        {
            float inputX = Input.GetAxis("R_XAxis_1");
            float inputZ = Input.GetAxis("R_YAxis_1");
            axisX = Input.GetAxis("R_XAxis_1");
            axisY = Input.GetAxis("R_YAxis_1");
            finalInputX = inputX + axisX;
            finalInputZ = inputZ + axisY;

            rotY += finalInputX * inputSensitivity * Time.deltaTime;


            rotX += finalInputZ * inputSensitivity * Time.deltaTime;

            rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

            Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
            transform.rotation = localRotation;
        }
        if (RangeAtack.ranged)
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
    void LateUpdate()
    {
        CameraUpdater();
        
    }
    void CameraUpdater()
    {

        
        Transform target = CameraFollowObj.transform;

        float step = CameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
       
        
    }
}
