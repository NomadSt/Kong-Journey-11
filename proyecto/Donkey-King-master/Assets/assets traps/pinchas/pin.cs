using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pin : MonoBehaviour
{
    public float timer0;//desfase antes de comenzar el ciclo

    public float timer1;//no tocar
    public float StayDown;
    public float timer3;//no tocar
    public float StayUp;

    public GameObject esferad;
    public Animator anime;

    public float fill;
    public float fillDelta = 0.03f;
    public float radFill;
    public Image image;

    public float Timeperc;
    public bool parpadear;
    public float parpTimer = 0.1f;
    public GameObject Red;
    public GameObject Green;
    public bool pasive;

    public Vector3 distancia3d;
    public float distancia;
    public float tolerancia;
    public SphereCollider trigger;
    public SphereCollider Hard;
    //vector auxiliar rote
    public Transform VectorAux;
    public Transform VectorAux2;
    public Transform VectorAux3;
    public float unitario1;
    public float unitario2;
    public float unitario3;
    public float DeltaXa;
    public float DeltaZa;

    public float anga;
    public float radiansa;
    public float radFaxa;
    public float radFaxe;

    public Vector2 offset;
    public GameObject pej;

    //Trail stuff
    public GameObject TrailCarrier;
    public int ran;
    // Start is called before the first frame update

    public void OnTriggerStay(Collider other)
    {
        //if (other.tag == "Wukong" & (anime.GetInteger("Fase") == 2 | anime.GetInteger("Fase") == 1))
        if (other.tag == "Wukong")
        {
            esferad.GetComponent<Damage>().activarHard = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wukong")
        {
            esferad.GetComponent<Damage>().activarHard = false;
        }
    }

    void Start()
    {
        esferad.SetActive(true);
        anime.SetInteger("Fase", 1);
        Invoke("Atck", timer0);
        Invoke("Parp1", parpTimer);
        pasive = false;
    }

    // Update is called once per frame
    public void Atck()
    {
        anime.SetInteger("Fase", 2);
        Invoke("StyOf", timer1);

        


    }
    public void StyOf()
    {


        esferad.SetActive(false);
        anime.SetInteger("Fase", 3);
        Invoke("Bck", StayDown);
        fill = (timer1 + StayDown) *Timeperc;

        Green.SetActive(true);
        parpadear = false;
        pasive = true;

        if (TrailCarrier != null)
            TrailCarrier.GetComponent<Animator>().SetBool("Up", false);
    }
    public void Bck()
    {

        anime.SetInteger("Fase", 0);
        Invoke("StyPas", timer3);


    }
    public void StyPas()
    {
        ran = Random.Range(1, 3);
        gameObject.GetComponent<SfxManager>().Play(ran.ToString());

        esferad.SetActive(true);
        anime.SetInteger("Fase", 1);
        Invoke("Atck", StayUp);


        parpadear = false;
        Green.SetActive(false);
        Red.SetActive(false);

        pasive = false;

        if (TrailCarrier != null)
            TrailCarrier.GetComponent<Animator>().SetBool("Up", true);

    }

    public void Parp1()
    {
        Invoke("Parp2", parpTimer);
        if(parpadear)
        {
            Green.SetActive(false);
            Red.SetActive(true);
        }
    }
    public void Parp2()
    {
        Invoke("Parp1", parpTimer);
        if (parpadear)
        {
            Green.SetActive(true);
            Red.SetActive(false);
        }
    }

    public void Update()
    {
        if (anime.GetInteger("Fase") == 3 | anime.GetInteger("Fase") == 0)//Quitar dureza mientras esta retraido
        {
                Hard.enabled = false;
                trigger.enabled = true;
        }
        if (anime.GetInteger("Fase") == 1 | anime.GetInteger("Fase") == 2)//Aplicar dureza ientras este arriba y fuera del radio
        {
            if (esferad.GetComponent<Damage>().activarHard == false)
            {
                Hard.enabled = true;
                trigger.enabled = false;
            }
        }
        //Rotar vector auxiliar segun jugador vs trampa
        pej = GameObject.FindGameObjectWithTag("Wukong");
        offset = new Vector2(transform.position.x, transform.position.z) - new Vector2(pej.transform.position.x, pej.transform.position.z);
        anga = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        radiansa = anga * Mathf.Deg2Rad;
        radiansa += radFaxa;
        float radianse = anga * Mathf.Deg2Rad;
        radianse += radFaxe;

        DeltaXa = Mathf.Cos(radiansa);
        DeltaZa = Mathf.Sin(radiansa);

        float DeltaXaa = Mathf.Cos(radianse);
        float DeltaZaa = Mathf.Sin(radianse);

        VectorAux.position = new Vector3((transform.position.x + DeltaXa * unitario1), transform.position.y, (transform.position.z + DeltaZa * unitario1));
        VectorAux2.position = new Vector3((transform.position.x + DeltaXa * unitario2), VectorAux2.position.y, (transform.position.z + DeltaZa * unitario2));
        VectorAux3.position = new Vector3((transform.position.x + DeltaXaa * unitario3), VectorAux2.position.y, (transform.position.z + DeltaZaa * unitario3));

        fill -= fillDelta * Time.deltaTime;
        radFill = (fill/((timer1 + StayDown) * Timeperc));
        image.fillAmount = radFill;

        if(fill < 0 & pasive == true)
        {
            parpadear = true;
        }
    }
}
