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


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        thisobj = this.gameObject;
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        //agent.autoBraking = false;

        GotoNextPoint();
    }

    void Update()
    {
        auxVida = VidaEnemigo.vida;
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (nearPlayer)
        {
            agent.isStopped = true;
            Follow();
            Attack();
        }
        if (!nearPlayer)
        {
            agent.isStopped = false;
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }
                
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
        if (agent.remainingDistance < 3.5f)
        {
            agent.isStopped = true;
        }
        if (agent.remainingDistance > 3.5f)
        {
            agent.isStopped = false;
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