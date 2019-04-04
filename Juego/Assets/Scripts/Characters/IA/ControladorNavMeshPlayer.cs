using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class ControladorNavMeshPlayer : MonoBehaviour
{

    [HideInInspector]
    public Transform perseguirObjectivo;

    private NavMeshAgent navMeshAgent;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void ActualizarPuntoDestinoNavMeshAgent(Vector3 puntoDestino)
    {
        if(Movimiento.pj == true)
        {
            navMeshAgent.destination = puntoDestino;
            navMeshAgent.isStopped = false;
        }
        
    }

    public void ActualizarPuntoDestinoNavMeshAgent()
    {
        if (Movimiento.pj == true)
        {
            ActualizarPuntoDestinoNavMeshAgent(perseguirObjectivo.position);

        }

    }

    public void DetenerNavMeshAgent()
    {
        if (Movimiento.pj == true)
        {
            navMeshAgent.isStopped = true;

        }
    }

    public bool HemosLlegado()
    {

        return navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending;
    }

    void Update()
    {
        ActualizarPuntoDestinoNavMeshAgent();
    }
}
