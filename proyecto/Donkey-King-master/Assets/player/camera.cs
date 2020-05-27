using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float zoomSpeed;
    public float minZoom;
    public float maxZoom;

    public float minYaw;
    public float maxYaw;

    public float minSaw;
    public float maxSaw;

    public float pitch;
    public float currentZoom;

    public float yawSpeed;
    public float currentYaw;

    public float sawSpeed;
    public float currentSaw;

    //Lugar de interes
    public GameObject interes;
    public bool esInteres;
    public Vector3 dir;
    public float rotSpeed = 5.0f;

    //Sensibilidad del mouse
    public float mouseSens = 0.5f;




    void Update()
    {
        mouseSens = PlayerPrefs.GetFloat("MouseSens");
        if (FindObjectOfType<Menu>().GetComponent<Menu>().UIactivo == false)
        {
            currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

            currentYaw += Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime * mouseSens;
            //currentYaw = Mathf.Clamp(currentYaw, minYaw, maxYaw);

            currentSaw += Input.GetAxis("Vertical") * sawSpeed * Time.deltaTime * mouseSens;
            currentSaw = Mathf.Clamp(currentSaw, minSaw, maxSaw);
        }

    }


    void LateUpdate()
    {
        //OLD
        pitch = currentSaw;
        transform.position = target.position - offset * currentZoom;

        if (esInteres == false)
        {
            transform.LookAt(target.position + Vector3.up * pitch);
            transform.RotateAround(target.position, Vector3.up, currentYaw);
        }
        if (esInteres)
        {
            dir = interes.transform.position - transform.position;
            Quaternion rap = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, rap, rotSpeed * Time.deltaTime);
        }
    }
}
