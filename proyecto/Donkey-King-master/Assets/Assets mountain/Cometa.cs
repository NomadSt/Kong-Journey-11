using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cometa : MonoBehaviour
{
    public GameObject CheckAux;

    public float superOffset;
    public Vector3 offset;
    public bool activated;
    public bool IsHidden;
    public GameObject[] checks;
    public bool touch;
    public GameObject plane;
    public bool invisible;

    // Start is called before the first frame update
    void Start()
    {
        CheckAux.SetActive(false);
        offset = new Vector3(transform.position.x, transform.position.y + superOffset, transform.position.z);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            checks = GameObject.FindGameObjectsWithTag("Respawn");
            plane.GetComponent<CheckRespawn>().touch = true;
            foreach (GameObject c in checks)
            {
                if (c.GetComponent<CheckRespawn>().touch == false)
                    c.SetActive(false);
            }
            Animation1.Respaun = new Vector3(offset.x, offset.y, offset.z);

            if (activated == false & IsHidden == false)
            {
                if(invisible == false)
                {

                GameObject.FindGameObjectWithTag("Wukong").GetComponent<SfxManager>().Play("chk");
                gameObject.GetComponent<SfxManager>().Play("1");
                }
                activated = true;
                CheckAux.SetActive(true);

            }
            if (invisible)
            {
                CheckAux.SetActive(true);
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            plane.GetComponent<CheckRespawn>().touch = false;
        }
    }
}
