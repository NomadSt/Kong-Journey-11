using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class selectCamera : MonoBehaviour
{
    public Slider mainSlider;
    public float slider;
    public float maximo;
    public float minimo;
    public float scroll;

    public bool mouseTouch;
    public float currentValue;

    public float currentZoom;
    public float zoomSpeed = 0.1f;

    public float minZ = 0.0f;
    public float maxZ = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GetTouch()
    {
        
            //mouseTouch = true;
    }


    // Update is called once per frame
    void Update()
    {
        if(mouseTouch == false)
        {
            currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed; //Mantener signo negativo o no funcionara
            currentZoom = Mathf.Clamp(currentZoom, minZ, maxZ);
            currentValue = -currentZoom;
            mainSlider.value = currentValue;
        }

        if(mouseTouch == true)
        {
            currentZoom = -mainSlider.value;
        }

        if (Input.GetMouseButton(0))
        {
            mouseTouch = true;
        }

        if (Input.GetMouseButton(0) == false)
        {
            mouseTouch = false;
        }

        slider = mainSlider.value;
        transform.position = new Vector3(transform.position.x, minimo + ((maximo - minimo) * slider), transform.position.z);
        
    }
}
