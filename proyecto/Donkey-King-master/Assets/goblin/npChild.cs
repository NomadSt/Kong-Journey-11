using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npChild : MonoBehaviour
{
    public Vector3 Target;

    public float radio;

    public int proc;

    public bool coles;

    public Vector3 poser;

    void Start()
    {
        enemyS enemy = GetComponentInParent<enemyS>();
        radio = enemy.radio;
    }

    public void Pos()
    {
        enemyS enemy = GetComponentInParent<enemyS>();
        transform.position = enemy.transform.position;

        proc = 1;
        Target = transform.position + Random.insideUnitSphere * radio;
        Target.y = transform.position.y;
        transform.position = Target;
        coles = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (proc == 1 && other.gameObject.tag == "Floor")
        {
            coles = false;
        }
        if (proc == 1 && other.gameObject.tag != "Floor")
        {
            coles = true;
            Pos();
        }

    }

    void Update()
    {
        if (coles == false && proc == 1)
        {

            proc = 2;
            poser = transform.position;
            enemyS enemy = GetComponentInParent<enemyS>();
            enemy.RecTarget(poser);
        }
    }

}
