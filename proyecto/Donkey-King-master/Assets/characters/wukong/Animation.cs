using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator anime;
    public bool fps = true;
    public bool fplock = false;
    public Vector3 offset;
    public Vector3 Localoffset;
    public float currentZoom;
    public Transform cam;
    public Transform Follow;
    public float currentYaw;

    //movimiento

    public Vector3 targetOffset;
    public Transform Target1;
    public Transform Total;
    public Transform Parcial;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("Fps", 2);
    }

    public void Fps()
    {
        fplock = true;
        Invoke("Fps", 2);
    }

    // Update is called once per frame
    void Update()
    {
        //Cambio modo FPS a TPS

        if (Input.GetKey(KeyCode.Space))
        {
            if(fps == false & fplock)
            {
                fps = true;
                fplock = false;
            }
            if (fps & fplock)
            {
                fps = false;
                fplock = false;
            }
        }

        if (fps)
            anime.SetBool("FPS", true);
        else
            anime.SetBool("FPS", false);

        //Animaciones según teclado

        if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.D))
        {
            anime.SetBool("Run", true);// Modifica el bool
        }
        if (Input.GetKeyUp(KeyCode.W) | Input.GetKeyUp(KeyCode.A) | Input.GetKeyUp(KeyCode.S) | Input.GetKeyUp(KeyCode.D))
        {
            anime.SetBool("Run", false);// Modifica el bool
        }

        //Cámara
        //Scam.position = transform.position - offset * currentZoom;
        //Scam.LookAt(transform.position + Vector3.up);

        //transform.RotateAround(transform.position, Vector3.up, currentYaw);
        if (fps == false)
            cam.transform.localPosition = offset;
        else
            cam.transform.localPosition = new Vector3 (0,0,0) + Localoffset;

        //Seguir VRTK
        transform.position = Target1.position + targetOffset;
        //rotar
        Parcial.position = new Vector3(Total.position.x, transform.position.y, Total.position.z);
        transform.LookAt(Parcial);

    }
}
