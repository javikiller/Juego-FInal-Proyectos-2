using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class MoveTo : MonoBehaviour
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
    public float contadorAtaque = 0;
    public Transform playerLookAt;
    public GameObject enemySword;
    private Rigidbody rb;
   

    void Start()
    {
        animator.SetBool(walkParam, true);
        agent = GetComponent<NavMeshAgent>();
        thisobj = this.gameObject;
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        //agent.autoBraking = false;
        enemySword.SetActive(false);
        GotoNextPoint();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        auxVida = VidaEnemigo.vida;
        // Choose the next destination point when the agent gets
        // close to the current one.
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
        if(VidaEnemigo.vida <= 0)
        {
            Destroy(this.gameObject);
        }
        
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

    void Follow()
    {
        agent.isStopped = false;
        agent.destination = target.position;
    }

    void Attack()
    {
        if (agent.remainingDistance < 2.5f)
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

   
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            nearPlayer = true;
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