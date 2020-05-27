using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCam : MonoBehaviour
{
    public float CameraMoveSpeed = 120.0f;
    public GameObject CameraFollowObj;
    Vector3 FollowPos;
    public float clampAngle = 80.0f;
    public float inputSensitivity = 150.0f;
    public GameObject cameraObj;
    public GameObject PlayerObj;
    public float camDistanceXToPlayer;
    public float camDistanceYToPlayer;
    public float camDistanceZToPlayer;
    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputZ;
    public float smoothX;
    public float smoothY;
    public float rotY = 0.0f;
    public float rotX = 0.0f;

    //Lugar de interes
    public GameObject interes;
    public bool esInteres;
    public Vector3 dir;
    public float rotSpeed = 5.0f;


    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Wukong");
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        //Cursor.lockState = CursorLockMode.Locked;
        //print("a1");
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Menu>().GetComponent<Menu>().UIactivo == false)//BETA
        {


            inputSensitivity = PlayerPrefs.GetFloat("MouseSensal");
            //transform.position = target.transform.position;
            //We setup the rotation of the sticks here
            float inputX = Input.GetAxis("Horizontal");
            float inputZ = -Input.GetAxis("Vertical");
            mouseX = Input.GetAxis("Mouse X");
            mouseX = Input.GetAxis("Mouse Y");
            finalInputX = inputX + mouseX;
            finalInputZ = inputZ + mouseY;

            rotY += finalInputX * inputSensitivity * Time.deltaTime;
            rotX += finalInputZ * inputSensitivity * Time.deltaTime;

            rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

            if (esInteres == false)
            {
                Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
                transform.rotation = localRotation;
            }
            else
            {
                dir = interes.transform.position - transform.position;
                Quaternion rap = Quaternion.LookRotation(dir, Vector3.up);
                transform.rotation = Quaternion.Lerp(transform.rotation, rap, rotSpeed * Time.deltaTime);
            }
        }
            
    }

    private void LateUpdate()
    {
        transform.position = CameraFollowObj.transform.position;
        //CameraUpdater();
        //print("a3");
    }

    void CameraUpdater()
    {
        //set the target object to follow
        Transform target = CameraFollowObj.transform;

        //move towards the game object that is the target
        float step = CameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        print("a4");
    }
}
