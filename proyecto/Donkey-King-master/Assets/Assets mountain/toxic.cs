using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toxic : MonoBehaviour
{
    public GameObject[] Positions;
    public bool onPosition;
    public int pivote;
    public float tolerancia = 0.5f;
    public float speed = 0.5f;
    public Vector3 distancia;
    public float dist;

    public GameObject ForStp;
    public List<GameObject> ForStptrap;
    public GameObject traps;
    public GameObject deco;
    public GameObject walls;
    public GameObject noReturn;
    public List<GameObject> Hide;

    public void Next()
    {
        pivote++;
        if (pivote == 3)
            FindObjectOfType<Gmanager>().ActiveTrap();
        if (pivote == 4)
            FindObjectOfType<Gmanager>().ActiveTrap();

        if (pivote == 5)
        {
            ForStp.SetActive(true);
            noReturn.SetActive(true);
            traps.SetActive(false);
            deco.SetActive(false);
            walls.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            foreach (GameObject i in Hide)
                i.SetActive(false);
            //foreach (GameObject i in ForStptrap)
            {
                //if (i != null & i.GetComponent<dardos>() != null & i.GetComponent<dardos>().AlwaysFire == false)
                  //  i.GetComponent<dardos>().Start();
                //if (i != null & i.GetComponent<roundBlade>() != null)
                  //  i.GetComponent<roundBlade>().StartCorrutine();
            }
            FindObjectOfType<Gmanager>().ActiveTrap();
        }
        if (pivote == 6)
        {
            walls.SetActive(true);
            walls.transform.localScale = new Vector3(1f, 1f, 1f);
            FindObjectOfType<Gmanager>().ActiveTrap();
        }
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Positions[pivote].transform.position - transform.position;
        dist = distancia.magnitude;
        if (distancia.magnitude < tolerancia)
            onPosition = true;
        else
            onPosition = false;

        if (onPosition == false)
            transform.Translate((Positions[pivote].transform.position - transform.position) * speed * Time.deltaTime);
    }
}
