using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public float rotTas;
    Collider m_Collider;
    public Vector3 dits;
    public GameObject Player;
    public float tolerancia;
    public float tol;
    public bool safe;
    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<Collider>();
        if (gameObject.tag == "key")
            FindObjectOfType<contador>().GetComponent<contador>().tCoin++;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" & safe == false)
        {
            GameObject.FindGameObjectWithTag("Wukong").GetComponent<SfxManager>().Play("coin");
            //FindObjectOfType<contador>().monedas += 1;
            //print(FindObjectOfType<Animation1>().key);
            FindObjectOfType<Animation1>().key += 1;
            FindObjectOfType<contador>().monedas += 1;
            //print(FindObjectOfType<Animation1>().key);
            safe = true;
            //print(safe);
            Destroy(gameObject);
            return;
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" & safe == false)
        {
            GameObject.FindGameObjectWithTag("Wukong").GetComponent<SfxManager>().Play("coin");
            //FindObjectOfType<contador>().monedas += 1;
            //print(FindObjectOfType<Animation1>().key);
            FindObjectOfType<Animation1>().key += 1;
            FindObjectOfType<contador>().monedas += 1;
            //print(FindObjectOfType<Animation1>().key);
            safe = true;
            //print(safe);
            Destroy(gameObject);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, rotTas));
    }
}
