using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida_Player : MonoBehaviour {

    //public GameObject lvlup;
    public static bool arco = false;
    public bool arcoactivo =false;
    public int nivel = 1;
    public float xp = 0;
    public static float exp = 0;
    public float vidaP = 100;
    public bool muerto = false;
    public static float stamina = 100;


    void Update()
    {        
        xp = exp;
        arcoactivo = arco;
        if (exp >= 100)
        {
            vidaP = 100;
            exp = 0;
            nivel += 1;
            //Instantiate(lvlup,transform.position,transform.rotation);
        }
        if (vidaP <= 0)
        {
            muerto = true;
        }
        if (vidaP >= 100)
        {
            vidaP = 100;
        }
        if (vidaP < 100 && vidaP > 0)
        {
            vidaP += 1 * Time.deltaTime;
        }
        if (muerto)
        {
            Destroy(this.gameObject);
        }
        

    }
}
