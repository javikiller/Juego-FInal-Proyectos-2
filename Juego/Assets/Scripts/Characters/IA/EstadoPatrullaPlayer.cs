using UnityEngine;
using System.Collections;

public class EstadoPatrullaPlayer : MonoBehaviour
{

    public Transform[] WayPoints;
    public Color ColorEstado = Color.green;

    private MaquinaDeEstadosPlayer maquinaDeEstados;
    private ControladorNavMeshPlayer controladorNavMesh;
    private ControladorVisionPlayer controladorVision;
    private int siguienteWayPoint;

    void Awake()
    {
        maquinaDeEstados = GetComponent<MaquinaDeEstadosPlayer>();
        controladorNavMesh = GetComponent<ControladorNavMeshPlayer>();
        controladorVision = GetComponent<ControladorVisionPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
            // Ve al jugador?
            RaycastHit hit;
            if (controladorVision.PuedeVerAlJugador(out hit))
            {
                controladorNavMesh.perseguirObjectivo = hit.transform;
                maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucionPlayer);
                return;
            }

        if (controladorNavMesh.HemosLlegado())
        {
            siguienteWayPoint = (siguienteWayPoint) % WayPoints.Length;
            ActualizarWayPointDestino();
        }



    }

    void OnEnable()
    {
        maquinaDeEstados.MeshRendererIndicador.material.color = ColorEstado;
        ActualizarWayPointDestino();
    }

    void ActualizarWayPointDestino()
    {
        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent(WayPoints[siguienteWayPoint].position);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (Movimiento.pj == true)
        {
           if (other.gameObject.CompareTag("Enemy") && enabled)
                {
                    maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlertaPlayer);
                }
        }
         
    }
}
