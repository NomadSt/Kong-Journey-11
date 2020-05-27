using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class portalScript : MonoBehaviour
{
    public int acces;
    public Animator anim;
    public float timer1;
    public Vector3 landa;
    public GameObject pej;
    public GameObject camSun;
    public GameObject camDung;
    public GameObject Mountain;
    public GameObject dungeon;

    public GameObject trap1;
    public GameObject trap2;

    public Text textChange;
    public int transpaso;
    public GameObject camara;
    public GameObject UI;

    public bool Interior;
    public bool IntKey;
    public bool seguro;

    //Elementos de exterior
    public List<GameObject> Exterior;
    //Elementos de interior
    public List<GameObject> Inter;
    //Terrenos
    public List<GameObject> Terrenos;
    //Elementos activar bool atc
    public List<GameObject> atcBool;
    public List<GameObject> atcDard;
    public List<GameObject> atcFlame;
    public List<GameObject> roundBlade;
    //Elementos activar trigger de monjes
    public List<GameObject> Monk;

    //Lose Change
    public Animator LoseChange;
    //si pone o quita player pref planta baja
    public int pBaja;//-1 quita, 0, mantiene, 1 hace verdadero

    //Grass
    public GameObject bigG;


    void Start()
    {
        LoseChange = GameObject.FindGameObjectWithTag("LosChange").GetComponent<Animator>();
        PlayerPrefs.SetInt("planta", 0);
        transpaso = acces;
    }

    void Update()
    {
        if (Interior == false | (Interior & IntKey))
        {
            textChange.text = transpaso.ToString();

            camara = GameObject.FindGameObjectWithTag("MainCamera");

            if (camara != null )
                UI.transform.LookAt(camara.transform);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(seguro == false & (other.tag == "Wukong"))
        {
            if (FindObjectOfType<Animation1>().key >= acces & Interior == false)
            {
                pej = GameObject.FindGameObjectWithTag("Wukong");
                anim.SetBool("Open", true);
                StartCoroutine(Move());
                print(FindObjectOfType<Animation1>().key);
                FindObjectOfType<Animation1>().key -= acces;
                print(FindObjectOfType<Animation1>().key);
                seguro = true;
                LoseChange.SetBool("show", true);
                FindObjectOfType<Player>().GetComponent<Player>().notMove = true;
                gameObject.GetComponent<SfxManager>().Play("open portal");

                //Player prefs
                if (pBaja == 1)
                    PlayerPrefs.SetInt("planta", 1);
                //print(PlayerPrefs.GetInt("planta"));

            }
            if (Interior & IntKey == false)
            {
                pej = GameObject.FindGameObjectWithTag("Wukong");
                anim.SetBool("Open", true);
                StartCoroutine(Move());
                seguro = true;
                LoseChange.SetBool("show", true);
                FindObjectOfType<Player>().GetComponent<Player>().notMove = true;
                gameObject.GetComponent<SfxManager>().Play("open portal");
            }
            if (Interior & IntKey & FindObjectOfType<Animation1>().key >= acces)
            {
                pej = GameObject.FindGameObjectWithTag("Wukong");
                anim.SetBool("Open", true);
                StartCoroutine(Move());
                seguro = true;
                LoseChange.SetBool("show", true);
                FindObjectOfType<Player>().GetComponent<Player>().notMove = true;
                FindObjectOfType<Animation1>().key -= acces;
                gameObject.GetComponent<SfxManager>().Play("open portal");
            }
        }

    }
    IEnumerator Move()
    {
        yield return new WaitForSeconds(timer1);
        {
            LoseChange.SetBool("show", false);
            FindObjectOfType<Player>().GetComponent<Player>().notMove = false;
            GameObject.FindGameObjectWithTag("Manager").GetComponent<Menu>().SfxChange();



            if (Interior == false)
            {
                pej.GetComponent<Animation1>().Tp(landa);//Mueve personaje
                //camSun.SetActive(false);
                //Mountain.SetActive(false);
                //dungeon.SetActive(true);
                //trap1.GetComponent<squareBlade>().atc = true;
                //trap2.GetComponent<squareBlade>().atc = true;
                FindObjectOfType<Menu>().GetComponent<Menu>().InDungeon = true;



                //Activa y desactiva elementos de interior y exterior
                foreach (GameObject i in Exterior)
                {
                    i.SetActive(false);
                }
                foreach (GameObject i in Inter)
                {
                    i.SetActive(true);
                }



                foreach (GameObject i in atcBool)
                {
                    if (i != null)
                        i.GetComponent<squareBlade>().atc = true;
                }
                foreach (GameObject i in atcDard)
                {
                    if (i != null)
                        i.GetComponent<dardos>().Start();
                }
                foreach (GameObject i in atcFlame)
                {
                    if (i != null)
                        i.GetComponent<Flamer>().Start();
                }
                foreach (GameObject i in roundBlade)
                {
                    if (i != null)
                        i.GetComponent<roundBlade>().StartCorrutine();
                }
            }
            if (Interior)
            {
                //print("Hauk");
                pej.GetComponent<Animation1>().Tp(landa);
                camSun.SetActive(true);
                Mountain.SetActive(true);
                dungeon.SetActive(false);

                FindObjectOfType<Menu>().GetComponent<Menu>().InDungeon = false;
                //Activa y desactiva elementos de interior y exterior
                foreach (GameObject i in Exterior)
                {
                    i.SetActive(true);
                    if (i != null & i.GetComponent<dardos>() != null)
                        i.GetComponent<dardos>().Start();
                    if (i != null & i.GetComponent<roundBlade>() != null)
                        i.GetComponent<roundBlade>().StartCorrutine();
                }
                foreach (GameObject i in Inter)
                {
                    i.SetActive(false);
                }

                foreach (GameObject i in Terrenos)
                {
                    if (FindObjectOfType<Menu>().terrainQuality == 1)
                        Terrenos[0].SetActive(true);
                    if (FindObjectOfType<Menu>().terrainQuality == 2)
                        Terrenos[1].SetActive(true);
                    if (FindObjectOfType<Menu>().terrainQuality == 3)
                        Terrenos[2].SetActive(true);
                }
                foreach (GameObject i in Monk)
                {
                    i.GetComponent<jud>().StartTrigger();
                }
            }
            bigG = GameObject.FindGameObjectWithTag("Manager");
            bigG.GetComponent<grassTrigger>().activeGrass();
            //print("GRASS POWER");
        }
    }
}
