using UnityEngine;
using System.Collections;

public class EstadoAlertaPlayer : MonoBehaviour
{

    public float velocidadGiroBusqueda = 120f;
    public float duracionBusqueda = 4f;
    public Color ColorEstado = Color.yellow;

    private MaquinaDeEstadosPlayer maquinaDeEstados;
    private ControladorNavMeshPlayer controladorNavMesh;
    private ControladorVisionPlayer controladorVision;
    private float tiempoBuscando;

    void Awake()
    {
        maquinaDeEstados = GetComponent<MaquinaDeEstadosPlayer>();
        controladorNavMesh = GetComponent<ControladorNavMeshPlayer>();
        controladorVision = GetComponent<ControladorVisionPlayer>();
    }

    void OnEnable()
    {
        maquinaDeEstados.MeshRendererIndicador.material.color = ColorEstado;
        controladorNavMesh.DetenerNavMeshAgent();
        tiempoBuscando = 0f;
    }

    void Update()
    {
        if (Movimiento.pj == true)
        {
            RaycastHit hit;
            if (controladorVision.PuedeVerAlJugador(out hit))
            {
                controladorNavMesh.perseguirObjectivo = hit.transform;
                maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucionPlayer);
                return;
            }

            transform.Rotate(0f, velocidadGiroBusqueda * Time.deltaTime, 0f);
            tiempoBuscando += Time.deltaTime;
            if (tiempoBuscando >= duracionBusqueda)
            {
                maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPatrullaPlayer);
                return;
            }

        }
        
    }
}
