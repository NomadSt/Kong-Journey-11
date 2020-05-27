using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyS : MonoBehaviour
{
    public float speed;
    public float rotSpeed;

    public Vector3 Target;
    public Vector3 dir;
    public Vector3 dar;

    public float radio;
    public float distTol;

    public float timerMin;
    public float timerMax;
    public float timer;

    public bool move = true;

    public Animator anime;
    public Transform goblinCh;

    public float exp;
    public float ezp;

    public Rigidbody rb;

    public float deltai;
    public float mi = 5.0f;

    public float oli;

    public void RecTarget(Vector3 posi)
    {

        Target = posi;

        timer = Random.Range(timerMin, timerMax);

        StartCoroutine(Descansar());

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radio);
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        goblinCh = this.gameObject.transform.GetChild(0);
        //anime = goblinCh.GetComponent<Animator>();

        npChild poet = GetComponentInChildren<npChild>();
        poet.Pos();
    }

    IEnumerator Descansar()
    {
        yield return new WaitForSeconds(timer);
        {
            move = true;
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Animation1.Goblins++;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        dir = Target - transform.position;




        if (dir.magnitude < distTol & move == true)
        {
            npChild poet = GetComponentInChildren<npChild>();
            poet.proc = 0;
            poet.Pos();

            move = false;
            anime.SetBool("Idle", true);
        }


        if (move == true)
        {
            anime.SetBool("Idle", false);
            Quaternion rap = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, rap, rotSpeed * Time.deltaTime);
            rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        }

        Debug.DrawLine(transform.position, Target, Color.red);

    }

}
