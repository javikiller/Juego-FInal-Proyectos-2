using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Movimiento : MonoBehaviour
{
    public static float life;
    public float auxLife;

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX ;
    public float sensitivityY ;
    public float velocidad = 200;
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

    public float contSalto = 0;

    public Animator animator;
    private float SpeedAux = 0;
    public float JumpAux = 0;
    private float vely;
    private float velx;

    private float acelerationFallCont = 0;
    public bool dmg = false;
    public float dmgAux = 0;
    public GameObject sword;
    public GameObject betterSword;
    public bool dmgOn = false;
    public float dmgOnAux;
    public static bool mejora = false;

    public float jumpx1;
    public float jumpx2;
    public bool jumpxOn1;
    public bool jumpxOn2;

    public bool muerto;
    public GameObject respanwn;

    void Start()
    {
        life = 200;
        camara.SetActive(true);
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        //GetComponent<Rigidbody>().rotation = Quaternion.identity;
        pj = false;

        muerto = false;
    }


    void FixedUpdate ()  
    {
        if(muerto == true)
        {
            this.gameObject.transform.position = respanwn.transform.position;
            muerto = false;
        }
        auxLife = life;

        life += 2 * Time.deltaTime;

        if(life >= 200)
        {
            life = 200;
        }

        if(life <= 0)
        {
            life = 0;
            muerto = true;
        }
               
        if (jumpxOn1)
        {
            contSalto += Time.deltaTime * 4.5f;
            jumpx1 += 1.5f * Time.deltaTime;
            animator.SetBool(jumpParam, true);
        }
        if (jumpx1 >= 1)
        {
            jumpx1 = 0;
            animator.SetBool(jumpParam, false);
            jumpxOn1 = false;
        }
        if (jumpxOn2)
        {
            jumpx2 += 1.5f * Time.deltaTime;
            animator.SetBool(doubleJumpParam, true);
        }
        if (jumpx2 >= 1)
        {
            jumpx2 = 0;
            animator.SetBool(doubleJumpParam, false);
            jumpxOn2 = false;
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
           
            animator.SetBool(dmgDoneParam, true);
            dmgOn = false;

        }
        else
        {
            animator.SetBool(dmgDoneParam, false);
            
        }

        if (pj == false)
        {
            Apuntar();
            Ataque();
            
            if (!RangeAtack.ranged)
            {
                MovementFunction();
                Giro();
                Jump();

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
                        dmg = false;
                    }
                }
                if (!dmg)
                {
                    dmgAux = 0;
                    sword.SetActive(false);
                    betterSword.SetActive(false);
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
            rb.AddForce(down * 19.8f * acelerationFallCont * 2);
            Velocidad = 150f;
        }
    }

    public void Jump()
    {

        if (Input.GetButtonDown("A_1") && ground)
        {
            rb.AddForce(rb.transform.up * 550);
            
            jumpxOn1 = true;
        }
        if(contSalto >= 1)
        {
            DoubleJump();

        }
        

    }
    public void DoubleJump()
    {
        if (Input.GetButtonDown("A_1") )
        {
            rb.AddForce(rb.transform.up * 550);
            contSalto = 0;
            jumpxOn2 = true;
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
            
            contSalto = 0;

        }
        if (coll.tag == "EspadaEnemiga" && !dmgOn)
        {
            RecibirDmg();
            life -= 20;
        }
        if (coll.tag == "BolaDmg")
        {
            RecibirDmg();
            life -= 30;
        }
        if(coll.tag == "aguamuerte")
        {
            muerto = true;
        }
    }
    private void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "floor")
        {
            ground = true;
        }
        if (coll.tag == "LentoDmg")
        {
            RecibirDmg();
            life -= 20* Time.deltaTime;
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
        //if (RangeAtack.ranged)
        //{
        //    float inputX = Input.GetAxis("R_XAxis_1");
        //    float inputZ = Input.GetAxis("R_YAxis_1");
        //    axisX = Input.GetAxis("R_XAxis_1");
        //    axisY = Input.GetAxis("R_YAxis_1");
        //    finalInputX = inputX + axisX;
        //    finalInputZ = inputZ + axisY;

        //    rotY += finalInputX * inputSensitivity * Time.deltaTime;


        //    rotX += finalInputZ * inputSensitivity * Time.deltaTime;

        //    rotX = Mathf.Clamp(rotX, -30, 10);

        //    Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        //    transform.rotation = localRotation;
        //}
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
        //if (ground)
        //{
        //    JumpAux += 1;
        //    rb.AddForce(rb.transform.up * 650);
           
        //}
        //if (!ground && contSalto == 1)
        //{
        //    rb.AddForce(rb.transform.up * 650);
        //    animator.SetBool(doubleJumpParam, true);
        //    animator.SetFloat(fallingParam, JumpAux, StartAnimTime, Time.deltaTime);
            
        //}
        //if (JumpAux >= 1)
        //{
        //    JumpAux = 0;
        //}
        

        //if (ground)
        //{            
            
        //    animator.SetBool(doubleJumpParam, false);
        //}

       

    }
   
    

    
}







