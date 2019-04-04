using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento2 : MonoBehaviour
{
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX;
    public float sensitivityY;
    public float velocidad = 5;
    public float salto = 10f;
    public float minimumY = -60F;
    public float maximumY = 60F;
    public float minimumX = -360F;
    public float maximumX = 360F;

    float rotationX = 0F;
    public Rigidbody rb;
    public float walkspeed;
    public GameObject camara1;
    public static bool pj;
    public GameObject camara;
    public GameObject terreno;
    public bool grounded = true;
    public GameObject Mirilla;
    public GameObject Mirilla1;

    public float axisX;
    public float axisY;
    public float finalInputX;
    public float finalInputZ;

    public float inputSensitivity = 150.0f;
    public float clampAngle = 80.0f;
    public float velBot = 5f;

    public Transform mira;
    public Transform ojos;

    public Vector3 direc;
    public float rotationSpeed;

    private Quaternion miraDireccion;
    private Quaternion rbDireccion;
    private Quaternion finalDireccion;

    private Vector3 desiredMovemntDirection;

    private float rotY = 0.0f;
    private float rotX = 0.0f;

    public bool ground;
    private float acelerationFallCont = 0;

    public static bool moovingObject = false;


    void Start()
    {
     
        rb = GetComponent<Rigidbody>();
        //GetComponent<Rigidbody>().rotation = Quaternion.identity;

    }
   


    void Update()
    {
        if (Movimiento.pj == true)
        {
            Saltar();
            MovementFunction();
            Giro();
        }
        if (ground)
        {
            acelerationFallCont = 0;
        }
        if (ground == false)
        {
            acelerationFallCont += 1f * Time.deltaTime;
            Vector3 down = new Vector3(0, -1, 0);
            rb.AddForce(down * 9.8f * acelerationFallCont);
        }
    }
    
    public void MovementFunction()
    {
        if(moovingObject == false)
        {
            if (Input.GetAxis("L_YAxis_1") < 0)
            {
                rb.AddForce((mira.transform.forward * Input.GetAxis("L_YAxis_1") * -30));
                if (Input.GetButton("LS_1") && ground)
                {
                    rb.AddForce((mira.transform.forward * Input.GetAxis("L_YAxis_1") * -120));
                }
            }
            if (Input.GetAxis("L_YAxis_1") > 0)
            {
                rb.AddForce((mira.transform.forward * Input.GetAxis("L_YAxis_1") * -30));
                if (Input.GetButton("LS_1") && ground)
                {
                    rb.AddForce((mira.transform.forward * Input.GetAxis("L_YAxis_1") * -120));
                }
            }
            if (Input.GetAxis("L_XAxis_1") > 0)
            {
                rb.AddForce((mira.transform.right * Input.GetAxis("L_XAxis_1") * 30));
                if (Input.GetButton("LS_1") && ground)
                {
                    rb.AddForce((mira.transform.right * Input.GetAxis("L_XAxis_1") * 120));
                }
            }
            if (Input.GetAxis("L_XAxis_1") < 0)
            {
                rb.AddForce((mira.transform.right * Input.GetAxis("L_XAxis_1") * 30));
                if (Input.GetButton("LS_1") && ground)
                {
                    rb.AddForce((mira.transform.right * Input.GetAxis("L_XAxis_1") * 120));
                }
            }
        }
        if (moovingObject)
        {
            if (Input.GetAxis("L_YAxis_1") < 0)
            {
                rb.AddForce((mira.transform.forward * Input.GetAxis("L_YAxis_1") * -30));
                
            }
            if (Input.GetAxis("L_YAxis_1") > 0)
            {
                rb.AddForce((mira.transform.forward * Input.GetAxis("L_YAxis_1") * -30));
                
            }
        }
    }

    public void Giro()
    {
        if(moovingObject == false)
        {
            Vector3 forward = camara1.transform.forward;
            Vector3 right = camara1.transform.right;

            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();

            desiredMovemntDirection = forward * -Input.GetAxis("L_YAxis_1") + right * Input.GetAxis("L_XAxis_1");
            if (Input.GetAxis("L_XAxis_1") + Input.GetAxis("L_YAxis_1") != 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMovemntDirection), 8f * Time.deltaTime);

            }
        }        

    }
    public void Saltar()
    {      
        if (Input.GetButtonDown("A_1") && ground)
        {
            rb.AddForce(rb.transform.up * 650);
            
        }               
    }

    void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "floor")
        {
            ground = true;
        }
        if (coll.tag == "Peso")
        {
            MovibleObject.touch = true;
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "floor")
        {
            ground = false;
        }
        if (coll.tag == "Peso")
        {
            MovibleObject.touch = false;
        }
    }



}
