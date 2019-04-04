using UnityEngine;
using System.Collections;

public class EstadoPersecucionPlayer : MonoBehaviour
{

    public Color ColorEstado = Color.red;

    private MaquinaDeEstadosPlayer maquinaDeEstados;
    private ControladorNavMeshPlayer controladorNavMesh;
    private ControladorVisionPlayer controladorVision;

    void Awake()
    {
        maquinaDeEstados = GetComponent<MaquinaDeEstadosPlayer>();
        controladorNavMesh = GetComponent<ControladorNavMeshPlayer>();
        controladorVision = GetComponent<ControladorVisionPlayer>();
    }

    void OnEnable()
    {
        maquinaDeEstados.MeshRendererIndicador.material.color = ColorEstado;
    }

    void Update()
    {
        if (Movimiento.pj == true)
        {    

            RaycastHit hit;
             if (!controladorVision.PuedeVerAlJugador(out hit, true))
             {
                 maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlertaPlayer);
                 return;
             }

            controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent();

        }
        
    }
}
