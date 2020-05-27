using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatRunner : MonoBehaviour
{
    public float followPrior;
    public float prior;
    public float pivot;
    public float pivotAnterior = 10;
    public List<GameObject> runPoints;
    public GameObject currentFollow;
    public float speed = 5.0f;
    public float rotSpeed = 3;
    public Vector3 rota;
    public Transform target;
    public Vector3 dir;
    public Vector3 dira;
    public Vector3 targ;
    public Vector3 normal;
    public Rigidbody rb;

    public float xVel;
    public float yVel;
    public float zVel;

    public float xVela;
    public float yVela;
    public float zVela;

    public float axisTol = 0.5f;
    public float axisTolDown = -0.5f;
    public float axisTolPlane = 0.1f;

    public GameObject coina;
    public float fixwai = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("run"))
        {
            if (runPoints != null & fooObj.GetComponent<runnere>() != null)
                runPoints.Add(fooObj);
        }
        oli();
    }
    public void OnTriggerEnter(Collider other)
    {
        
        //print("hail hydra");
        if (other.gameObject.GetComponent<runnere>() != null )
        {
            if(other.gameObject.GetComponent<runnere>().prior >= followPrior & other.gameObject.GetComponent<runnere>().prior < followPrior + 1)
            {
                prior = other.gameObject.GetComponent<runnere>().prior;
                pivotAnterior = 999;
                oli();
                speed = other.gameObject.GetComponent<runnere>().newVel;

                if (other.gameObject.GetComponent<runnere>().coin)
                {
                    CoinGen();
                }
            }

        }
    }
    public void CoinGen()
    {
        Instantiate(coina, new Vector3(transform.position.x, transform.position.y + fixwai, transform.position.z), Quaternion.identity);
    }

    public void oli()
    {

        foreach (GameObject grax in runPoints)
        {
            //print(grax.GetComponent<runnere>().prior);
            if (grax != null)
            {
                pivot = grax.GetComponent<runnere>().prior;
                if (pivot > prior & pivot < pivotAnterior)
                {
                    //print(pivot);
                    followPrior = pivot;
                    currentFollow = grax;
                    target = grax.transform;
                    //target.position = new Vector3(target.position.x, transform.position.y, target.position.z);
                    pivotAnterior = pivot;
                }
                    
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFollow != null)
        {

            //transform.Translate(((currentFollow.transform.position - transform.position).normalized) * speed * Time.deltaTime);
            //transform.LookAt(target);
            //transform.Rotate(new Vector3(0f, rotSpeed, 0f));
            dir = new Vector3(target.position.x, transform.position.y, target.position.z) - transform.position;
            Quaternion rap = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, rap, rotSpeed * Time.deltaTime);

            targ = target.position;
            dira = targ - transform.position;
            normal = dira.normalized;//Velocidad constante para cualquier index del teclado
            rb.MovePosition(transform.position + (normal * speed * Time.deltaTime));
        }
    }
    
    
}
