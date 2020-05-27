using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPosition : MonoBehaviour
{
    public GameObject Player;

    public Transform Norte;
    public Transform NorEste;
    public Transform Este;
    public Transform SurEste;
    public Transform Sur;
    public Transform SurOeste;
    public Transform Oeste;
    public Transform NorOeste;

    //Offset

    public float N;
    public float NE;
    public float E;
    public float SE;
    public float S;
    public float SW;
    public float W;
    public float NW;

    public float unitario;
    public GameObject caamera;
    public float camrRot;

    // obtiene la posicion del player, ajustando las bolas direccionales
    void FixedUpdate()
    {
        transform.position = Player.transform.position;
        camrRot = caamera.transform.eulerAngles.y;

        Norte.position = new Vector3((transform.position.x + (Mathf.Cos(-(camrRot + N )* Mathf.Deg2Rad)) * unitario), transform.position.y, (transform.position.z + (Mathf.Sin(-(camrRot + N) * Mathf.Deg2Rad)) * unitario));
        NorEste.position = new Vector3((transform.position.x + (Mathf.Cos(-(camrRot + NE) * Mathf.Deg2Rad)) * unitario), transform.position.y, (transform.position.z + (Mathf.Sin(-(camrRot + NE) * Mathf.Deg2Rad)) * unitario));
        Este.position = new Vector3((transform.position.x + (Mathf.Cos(-(camrRot + E) * Mathf.Deg2Rad)) * unitario), transform.position.y, (transform.position.z + (Mathf.Sin(-(camrRot + E) * Mathf.Deg2Rad)) * unitario));
        SurEste.position = new Vector3((transform.position.x + (Mathf.Cos(-(camrRot + SE) * Mathf.Deg2Rad)) * unitario), transform.position.y, (transform.position.z + (Mathf.Sin(-(camrRot + SE) * Mathf.Deg2Rad)) * unitario));
        Sur.position = new Vector3((transform.position.x + (Mathf.Cos(-(camrRot + S) * Mathf.Deg2Rad)) * unitario), transform.position.y, (transform.position.z + (Mathf.Sin(-(camrRot + S) * Mathf.Deg2Rad)) * unitario));
        SurOeste.position = new Vector3((transform.position.x + (Mathf.Cos(-(camrRot + SW) * Mathf.Deg2Rad)) * unitario), transform.position.y, (transform.position.z + (Mathf.Sin(-(camrRot + SW) * Mathf.Deg2Rad)) * unitario));
        Oeste.position = new Vector3((transform.position.x + (Mathf.Cos(-(camrRot + W) * Mathf.Deg2Rad)) * unitario), transform.position.y, (transform.position.z + (Mathf.Sin(-(camrRot + W) * Mathf.Deg2Rad)) * unitario));
        NorOeste.position = new Vector3((transform.position.x + (Mathf.Cos(-(camrRot + NW) * Mathf.Deg2Rad)) * unitario), transform.position.y, (transform.position.z + (Mathf.Sin(-(camrRot + NW) * Mathf.Deg2Rad)) * unitario));

    }
}
