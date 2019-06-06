using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class MoveTo : MonoBehaviour
{
    public Transform[] points;
    public Transform target;
    public Transform target2;
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
    public float vida;
    public bool vivo;
    public bool damaged;

    void Start()
    {
        animator.SetBool(walkParam, true);
        agent = GetComponent<NavMeshAgent>();
        thisobj = this.gameObject;
        
        enemySword.SetActive(false);
        GotoNextPoint();
        //rb = GetComponent<Rigidbody>();
        vida = 100;
        vivo = true;
    }

    void FixedUpdate()
    {
        if (vida <= 0)
        {
            vivo = false;
        }
        if (vivo == true)
        {
            animator.SetBool(mortoParam, false);
            auxVida = vida;

            if (nearPlayer)
            {
                transform.LookAt(playerLookAt);
                agent.isStopped = true;
                Follow();
                Attack();
                animator.SetBool(walkParam, false);
                animator.SetBool(followParam, true);
            }
            if (!nearPlayer)
            {
                agent.isStopped = false;
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    GotoNextPoint();
                }
                animator.SetBool(walkParam, true);
                animator.SetBool(followParam, false);
            }
            if (damaged)
            {
                animator.SetBool(dmgTakenParam, true);
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
                    damaged = false;
                    animator.SetBool(dmgTakenParam, false);                   
                }
            }
        }
        
        if (!vivo)
        {
            VidaELento.vida = 0;
            animator.SetBool(mortoParam, true);
            animator.SetBool(walkParam, false);
            animator.SetBool(followParam, false);
            animator.SetBool(combatParam, false);
            animator.SetBool(fwParam, false);
            animator.SetBool(dmgTakenParam, false);
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
        if (agent.remainingDistance < 4f)
        {
            animator.SetBool(followParam, false);
            animator.SetBool(fwParam, false);
            contadorAtaque += 1 * Time.deltaTime;
            agent.isStopped = true;
            if(contadorAtaque <= 0.75f)
            {
                enemySword.SetActive(true);
                animator.SetBool(combatParam, true); 
            }
            if(contadorAtaque >= 1)
            {
                animator.SetBool(combatParam, false);
                enemySword.SetActive(false);

            }
            if (contadorAtaque >= 3)
            {
                
                contadorAtaque = 0;
            }

        }
        if (agent.remainingDistance > 2.5f)
        {            
            agent.isStopped = false;
            animator.SetBool(fwParam, true);
            animator.SetBool(combatParam, false);
            animator.SetBool(followParam, true);
        }
    }

  

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            nearPlayer = true;
        }
        if (other.tag == "Espada" )
        {
            RecibirDmg();
            vida -= 10;
            damaged = true;
        }
        if (other.tag == "Espada2")
        {
            RecibirDmg();
            vida -= 20;
            damaged = true;
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