using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Movimiento : MonoBehaviour
{
    public float life;

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX ;
    public float sensitivityY ;
    public float velocidad = 5;
    public float salto = 10f;
    public float minimumY = -60F;
    public float maximumY = 60F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    

    public Rigidbody rb;
    public float walkspeed;
    public GameObject camara1;
    public static bool pj;
    public bool pjAux;
    public GameObject camara;
    public CapsuleCollider col;
    public GameObject Mirilla;
    public GameObject Mirilla1;
    public bool ground;
    
    public string motionParam = "motion";
    public string jumpParam = "jump";
    public string doubleJumpParam = "doubleJump";
    public string fallingParam = "jumpFall";
    public string attackParam = "attack";
    public string dmgDoneParam = "dmgDone";

    [Range(0, 1f)]
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.15f;

    public float axisX;
    public float axisY;
    public float finalInputX;
    public float finalInputZ;
  
    public float inputSensitivity = 150.0f;
    public float clampAngle = 80.0f;
    public float velBot = 5f;
    public float Velocidad = 80;

    public Transform mira;
    public Transform ojos;

    public Vector3 direc;
    public float rotationSpeed;

    public GameObject CameraFollowObjChange;
    public GameObject CameraFollowObjChangeAux;

    private Quaternion miraDireccion;
    private Quaternion rbDireccion;
    private Quaternion finalDireccion;

    private Vector3 desiredMovemntDirection;

    private float rotY = 0.0f;
    private float rotX = 0.0f;

    public float contSalto= 0;

    public Animator animator;
    private float SpeedAux = 0;
    public float JumpAux = 0;
    private float vely = Input.GetAxis("L_YAxis_1");
    private float velx = Input.GetAxis("L_XAxis_1");

    private float acelerationFallCont = 0;
    public bool dmg = false;
    public float dmgAux = 0;
    public GameObject sword;
    public GameObject betterSword;
    public bool dmgOn = false;
    public float dmgOnAux;
    public static bool mejora = false;


    void Start()
    {
        life = 200;
        camara.SetActive(true);
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        //GetComponent<Rigidbody>().rotation = Quaternion.identity;
        pj = false;

    }


    void Update ()  
    {
        life += 2 * Time.deltaTime;

        if(life >= 200)
        {
            life = 200;
        }
        if(life <= 0)
        {
            life = 0;
        }

        pjAux = pj;
        if (Input.GetAxis("DPad_YAxis_1") == 1)
        {
            CameraFollow.CameraFollowObjAux = CameraFollowObjChange;
            pj = true;

        }
        if (Input.GetAxis("DPad_XAxis_1") == 1)
        {
            CameraFollow.CameraFollowObjAux = CameraFollowObjChangeAux;
            pj = false;

        }

        if (dmgOn)
        {
            dmgOnAux += 1 * Time.deltaTime;
            animator.SetBool(dmgDoneParam, true);
            if (dmgOnAux >= 1)
            {
                
               
                dmgOnAux = 0;
                dmgOn = false;
                
            }
            if (dmgOnAux == 0)
            {
                animator.SetBool(dmgDoneParam, false);
            }

        }
        
        if (pj == false)
        {
            Apuntar();
            Ataque();
            
            if (!RangeAtack.ranged)
            {
                MovementFunction();
                Giro();
                Saltar();

                vely = Input.GetAxis("L_YAxis_1");
                velx = Input.GetAxis("L_XAxis_1");

                if (dmg)
                {
                    dmgAux += 1 * Time.deltaTime;
                    sword.SetActive(true);
                    betterSword.SetActive(true);
                    if (dmgAux >= 0.6f)
                    {
                        sword.SetActive(false);
                        betterSword.SetActive(false);
                    }
                }
                if (!dmg)
                {
                    dmgAux = 0;
                    sword.SetActive(false);
                    betterSword.SetActive(false);
                }
                if (dmgAux >= 1.2f)
                {
                    dmg = false;
                }


                


                if (Input.GetButton("LS_1"))
                {
                    SpeedAux = 1.5f;
                }
                else
                {
                    SpeedAux = new Vector2(vely, velx).normalized.sqrMagnitude;
                }

                animator.SetFloat(motionParam, SpeedAux, StartAnimTime, Time.deltaTime);

                if (Input.GetButton("LS_1"))
                {
                    
                     SpeedAux = 1.5f;
                }   
                else
                {
                    SpeedAux = new Vector2(vely, velx).normalized.sqrMagnitude;
                }
            }
            if (RangeAtack.ranged)
            {
                animator.SetFloat(motionParam, 0, StartAnimTime, Time.deltaTime);
            }
        }
        if (pj)
        {
            animator.SetFloat(motionParam, 0, StartAnimTime, Time.deltaTime);
        }
        if (ground)
        {
            acelerationFallCont = 0;
            Velocidad = 80;
            
        }
        if(ground == false)
        {
            acelerationFallCont += 1f * Time.deltaTime;
            Vector3 down = new Vector3(0, -1, 0);
            rb.AddForce(down * 19.8f * acelerationFallCont);
            Velocidad = 150f;
        }
    }

    public void RecibirDmg()
    {
        dmgOn = true;                
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "floor")
        {
            ground = true;

        }
        if (coll.tag == "EspadaEnemiga" && !dmgOn)
        {
            RecibirDmg();
            life -= 20;
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "floor")
        {
            ground = false;
        }
      
    }

    public void Ataque()
    {
        if (Input.GetAxis("TriggersR_1") != 0 && !dmg)
        {
            dmg = true;                    
            

            animator.SetBool(attackParam,true);
        }
        if (Input.GetAxis("TriggersR_1") == 0)
        {
            animator.SetBool(attackParam, false);
        }

    }

    public void Apuntar()
    {
        if (RangeAtack.ranged)
        {
            float inputX = Input.GetAxis("R_XAxis_1");
            float inputZ = Input.GetAxis("R_YAxis_1");
            axisX = Input.GetAxis("R_XAxis_1");
            axisY = Input.GetAxis("R_YAxis_1");
            finalInputX = inputX + axisX;
            finalInputZ = inputZ + axisY;

            rotY += finalInputX * inputSensitivity * Time.deltaTime;


            rotX += finalInputZ * inputSensitivity * Time.deltaTime;

            rotX = Mathf.Clamp(rotX, -30, 10);

            Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
            transform.rotation = localRotation;
        }
    }

    

    public void MovementFunction()
    {
        if (Input.GetAxis("L_YAxis_1") < 0)
        {
            rb.AddForce((mira.transform.forward * Input.GetAxis("L_YAxis_1") * -Velocidad));
            if (Input.GetButton("LS_1") && ground)
            {
                rb.AddForce((mira.transform.forward * Input.GetAxis("L_YAxis_1") * -(Velocidad + (Velocidad/2))));
            }
        }
        if (Input.GetAxis("L_YAxis_1") > 0)
        {
            rb.AddForce((mira.transform.forward * Input.GetAxis("L_YAxis_1") * -Velocidad));
            if (Input.GetButton("LS_1") && ground)
            {
                rb.AddForce((mira.transform.forward * Input.GetAxis("L_YAxis_1") * -(Velocidad + (Velocidad / 2))));
            }
        }
        if (Input.GetAxis("L_XAxis_1") > 0)
        {
            rb.AddForce((mira.transform.right * Input.GetAxis("L_XAxis_1") * Velocidad));
            if (Input.GetButton("LS_1") && ground)
            {
                rb.AddForce((mira.transform.right * Input.GetAxis("L_XAxis_1") * (Velocidad + (Velocidad / 2))));
            }
        }
        if (Input.GetAxis("L_XAxis_1") < 0)
        {
            rb.AddForce((mira.transform.right * Input.GetAxis("L_XAxis_1") * Velocidad));
            if (Input.GetButton("LS_1") && ground)
            {
                rb.AddForce((mira.transform.right * Input.GetAxis("L_XAxis_1") * (Velocidad + (Velocidad / 2))));
            }
        }
    }

    public void Giro()
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

    public void Saltar()
    {

        animator.SetBool(jumpParam, true);

        if (Input.GetButtonDown("A_1") && contSalto ==0)
        {
            JumpAux += 1 * Time.deltaTime;
            rb.AddForce(rb.transform.up * 650);
            
            contSalto += 1;
            
            if (Input.GetButtonDown("A_1") && contSalto == 1)
            {
                rb.AddForce(rb.transform.up * 650);
                animator.SetBool(doubleJumpParam, true);
                JumpAux = 0;
                animator.SetFloat(fallingParam, JumpAux, StartAnimTime, Time.deltaTime);
            }
            if(JumpAux >= 1)
            {
                JumpAux = 0;
            }
        }
       
        if (ground)
        {
            contSalto = 0;
            animator.SetBool(jumpParam, false);
            animator.SetBool(doubleJumpParam, false);
        }

       

    }
   


    
}







