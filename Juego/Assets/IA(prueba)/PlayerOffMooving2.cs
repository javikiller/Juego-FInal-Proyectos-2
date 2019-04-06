using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class PlayerOffMooving2 : MonoBehaviour
{
        
    public Transform target;    
    private NavMeshAgent agent;
    
    public bool nearEnemy = false;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!Movimiento.pj)
        {
            if (nearEnemy)
            {
                agent.isStopped = true;
                
                Attack();
            }
            if (!nearEnemy)
            {
                agent.isStopped = false;
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    GotoNextPoint();
                }

            }
        }
        
    }

    void GotoNextPoint()
    {
        agent.destination = target.position;
    }

    

    void Attack()
    {
        if (agent.remainingDistance < 2.5f)
        {
            agent.isStopped = true;
        }
        if (agent.remainingDistance > 2.5f)
        {
            agent.isStopped = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            nearEnemy = true;
            agent.destination = other.transform.position;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            nearEnemy = false;
            agent.destination = target.position;
        }
    }
}