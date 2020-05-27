using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinUI : MonoBehaviour
{
    public GameObject camara;
    public GameObject player;
    public GameObject child;
    public GameObject child2;
    public GameObject child3;
    public GameObject Parent;

    public Vector3 distancia3d;
    public float distancia;

    public Vector3 distancia3dClose;
    public float distanciaClose;

    public Vector3 distancia3dFar;
    public float distanciaFar;

    public float tolerancia;
    public float minTol;

    public bool close;
    public Transform AuxPosition;
    public Transform closePos;
    public Transform FarPos;

    public float speed;
    public float speed2;

    public float currentScale;
    public float MinScale;
    public float MaxScale;
    public float deltaScale;


    // Start is called before the first frame update
    void Start()
    {
        MaxScale = transform.localScale.x;
        currentScale = MaxScale;

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Wukong");
        camara = GameObject.FindGameObjectWithTag("MainCamera");
        if(player != null & camara != null)
        {
            //Rotacion
            if (camara != null & child != null & child2 != null & child3 != null)
            {

                child.transform.LookAt(camara.transform);
                child2.transform.LookAt(camara.transform);
                child3.transform.LookAt(camara.transform);
            }
            //Calculos
            distancia3d = Parent.transform.position - player.transform.position;
            distancia = distancia3d.magnitude;

            distancia3dClose = transform.position - closePos.transform.position;
            distanciaClose = distancia3dClose.magnitude;

            distancia3dFar = transform.position - FarPos.transform.position;
            distanciaFar = distancia3dFar.magnitude;

            if (distancia < tolerancia)
            {
                close = true;
            }
            else
                close = false;
            //Posicion & Escala
            if (close & distanciaFar > minTol)
            {
                transform.Translate((closePos.position - transform.position) * speed2 * Time.deltaTime);
                if (currentScale > MinScale)
                    currentScale -= deltaScale;
                if (currentScale < MinScale)
                    currentScale = MinScale;
            }

            if (close == false & distanciaClose > minTol)
            {
                transform.Translate((FarPos.position - transform.position) * speed * Time.deltaTime);
                if (currentScale < MaxScale)
                    currentScale += deltaScale;
                if (currentScale > MaxScale)
                    currentScale = MaxScale;



            }



            //Escala
            transform.localScale = new Vector3(currentScale, currentScale, currentScale);
        }
        
    }
}
