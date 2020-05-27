using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAvoidCollision : MonoBehaviour
{
    //Avoid collision
    public float minDst = 1.0f;
    public float maxDst = 4.0f;
    public float smooth = 10.0f;
    Vector3 dollyDir;
    Vector3 dollyDirFix;
    public float distance;
    public Vector3 OffFix;

    //Zoom
    public float currentZoom;
    public float zoomSpeed = 5;
    public float fix = 0.9f;

    // Start is called before the first frame update
    private void Awake()
    {
        currentZoom = PlayerPrefs.GetFloat("Wheel");
    }

    // Update is called once per frame
    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;//Mantener signo negativo o no funcionara
        currentZoom = Mathf.Clamp(currentZoom, minDst, maxDst);
        PlayerPrefs.SetFloat("Wheel", currentZoom);

        dollyDir = (transform.localPosition + OffFix).normalized;
        distance = (transform.localPosition + OffFix).magnitude;
        //Avoid Collision

        Vector3 desiredPosition = transform.parent.TransformPoint(dollyDir * maxDst);
        RaycastHit hit;

        if (Physics.Linecast(transform.parent.position, desiredPosition, out hit))
        {
            distance = Mathf.Clamp((hit.distance * fix), minDst, maxDst);
        }
        else
        {
            distance = currentZoom;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
    }
}
