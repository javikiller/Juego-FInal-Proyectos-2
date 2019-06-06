using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class EnemigoBola : MonoBehaviour
{
    public Transform[] points;
    public Transform target;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public GameObject thisobj;
    public bool nearPlayer = false;
    public float auxVida;
    public string walkParam = "walking";
    public string followParam = "follow";
    public string combatParam = "combat";
    public string fwParam = "followCombat";
    public static string dmgTakenParam = "dmgTaken";
    public string mortoParam = "morto";
    public bool dmgOn = false;
    public float dmgOnAux;
    public float contadorAtaque = 0;
    public Transform playerLookAt;
    private Rigidbody rb;

    public float vida;
    public bool vivo;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        thisobj = this.gameObject;

        vida = 35;
        vivo = true;
        GotoNextPoint();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
       if(vida <= 0)
        {
            vivo = false;
        }

        if (vivo)
        {
            
            

            if (BolaVision.detected)
            {
                transform.LookAt(playerLookAt);
                agent.isStopped = true;
                Follow();
                Attack();
                
            }
            if (!BolaVision.detected)
            {
                agent.isStopped = false;
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    GotoNextPoint();
                }
               
            }
            

            
        }
        
        if (!vivo)
        {
            Destroy(this.gameObject);
        }
    }
    
  

    public void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        agent.destination = points[destPoint].position;

      
        destPoint = (destPoint + 1) % points.Length;
    }

    public void Follow()
    {
        agent.isStopped = true;

        

        if (agent.remainingDistance < 2.5f)
        {
            agent.isStopped = true;
            
        }
        if (agent.remainingDistance > 2.5f)
        {
            rb.AddForce(rb.transform.forward * 15);
            //agent.isStopped = false;
        }
    }

    void Attack()
    {
        //if (agent.remainingDistance < 2.5f)
        //{
            
        //    contadorAtaque += 1 * Time.deltaTime;
        //    agent.isStopped = true;
            
        //    if (contadorAtaque >= 3)
        //    {

        //        contadorAtaque = 0;
        //    }

        //}
        //if (agent.remainingDistance > 2.5f)
        //{
        //    agent.isStopped = false;
            
        //}
    }

  

    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Espada")
        {
            vida -= 10;

        }
        if (other.tag == "Espada2")
        {
            vida -= 20;
        }

    }
    void OnTriggerExit(Collider other)
    {
        
    }
}   