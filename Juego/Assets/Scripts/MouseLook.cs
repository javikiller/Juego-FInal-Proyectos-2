using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour
{


    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
  


    public float minimumY = 3;
    public float maximumY = 3;

    public static float rotationY = 0F;
    public static float rotationX = 0F;

    public Transform objetivo;

    void Update()
    {

        transform.LookAt(objetivo);
        if (axes == RotationAxes.MouseXAndY)
        {
           

            rotationY += Input.GetAxis("R_YAxis_1") ;
            rotationY = Mathf.Clamp(rotationY, -20, 30);

            //rotationX += Input.GetAxis("R_XAxis_1") * sensitivityX;
            //rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);

            transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
        }
        
    }

    void Start()
    {
      
       
    }
}