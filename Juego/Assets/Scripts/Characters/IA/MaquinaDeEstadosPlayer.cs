using UnityEngine;
using System.Collections;

public class MaquinaDeEstadosPlayer : MonoBehaviour
{

    public MonoBehaviour EstadoPatrullaPlayer;
    public MonoBehaviour EstadoAlertaPlayer;
    public MonoBehaviour EstadoPersecucionPlayer;
    public MonoBehaviour EstadoInicial;

    public MeshRenderer MeshRendererIndicador;

    private MonoBehaviour estadoActual;

    void Start()
    {       
        
       ActivarEstado(EstadoPatrullaPlayer);

        
    }

    void Update()
    {
        if(Movimiento.pj == true)
        {
            ActivarEstado(EstadoPatrullaPlayer);

        }
    }

    public void ActivarEstado(MonoBehaviour nuevoEstado)
    {
        if (estadoActual != null) estadoActual.enabled = false;
        estadoActual = nuevoEstado;
        estadoActual.enabled = true;
    }

}
