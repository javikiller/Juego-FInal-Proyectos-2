using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarraDeVidaPlayer : MonoBehaviour
{

    public Scrollbar HealthBar;
    //public float Health = 100;

    private void Update()
    {
        HealthBar.size = Movimiento.life/ 200; 
    }
    //public void Damage(float value)
    //{
    //    Health -= value;
    //    HealthBar.size = Health / 100f;
    //}

}
