using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class EnemigoLento : MonoBehaviour
{
    public Transform[] points;
    public Transform target;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public GameObject thisobj;
    public bool nearPlayer = false;
    public float auxVida;
    public Animator animator;
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
    public GameObject enemySword;
    //private Rigidbody rb;
    public GameObject dmg;
    


    void Start()
    {
        dmg.SetActive(false);
        agent = GetComponent<NavMeshAgent>();
        thisobj = this.gameObject;
  
        GotoNextPoint();
        //rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        if (VidaEL.alaif == true)
        {
            auxVida = VidaEL.vida;

            if (LentoVisio0n.detected)
            {
                transform.LookAt(playerLookAt);
                agent.isStopped = true;
                Follow();
                Attack();

            }
            if (!LentoVisio0n.detected)
            {
                agent.isStopped = false;
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    GotoNextPoint();
                }

            }
            if (VidaEL.damaged)
            {
            }

            if (dmgOn)
            {
                dmgOnAux += 1 * Time.deltaTime;
                
                if (dmgOnAux >= 1)
                {
                    dmgOnAux = 0;
                    dmgOn = false;
                }
                if (dmgOnAux == 0)
                {
                }
            }
        }
        
        if (!VidaEL.alaif)
        {
            VidaEL.vida = 0;
        }
    }

    public void RecibirDmg()
    {
        dmgOn = true;
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
        agent.isStopped = false;
        agent.destination = target.position;
    }

    void Attack()
    {
        if (agent.remainingDistance < 2.5f)
        {
            contadorAtaque += 1 * Time.deltaTime;
            agent.isStopped = true;
            if (contadorAtaque <= 1)
            {
                dmg.SetActive(false);
            }
            if (contadorAtaque >= 1)
            {
                dmg.SetActive(true);
            }
            if (contadorAtaque >= 3)
            {
                contadorAtaque = 0;
            }

        }
        if (agent.remainingDistance > 2.5f)
        {
            agent.isStopped = false;
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            nearPlayer = true;
        }
        if (other.tag == "Espada" && !dmgOn)
        {
            RecibirDmg();            
        }
      
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            nearPlayer = false;
        }
       
        
    }
}   