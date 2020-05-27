using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Animation1 : MonoBehaviour
{
    public int key;
    public int ky;
    public int vd;
    public int intent;
    public static int jumpKey = 0;
    public static int intentos = 3;
    public static int vidas = 5;
    public static Vector3 Respaun;
    public Vector3 ResMon;
    public GameObject pj;
    public float timer1 = 5;
    public GameObject camSun;
    public GameObject dungeon;

    public static bool inmortals;
    public float imortalTimer = 3;
    public float unlockTimer = 1.0f;
    public bool inmorMonitor;
    public static int Goblins;

    public GameObject[] startHide;
    //Start Game
    public int intentosStart = 3;
    public int vidasStart = 5;

    // Lose game
    public Animator LoseChange;
    public Animator GameOver;
    public GameObject GameOvers;

    //Respawn
    public bool cancel;
    public float timerRespawn = 0.5f;

    //Grass
    public GameObject bigG;

    public void TpCorrutineTrigger()
    {
        StartCoroutine(Teleport());
    }
    IEnumerator Teleport()
    {
        //print("corrutina");

        yield return new WaitForSeconds(timerRespawn);
        {
            Respauwn();
            //print("corrutina2");
            cancel = false;

            if ((Animation1.intentos == 0 & Animation1.vidas < 1) | Animation1.intentos < 0)
                cancel = true;

            if (cancel == false)
            {
                //pej.GetComponent<Player>().CanaMove();
                LoseChange.SetBool("show", false);
                LoseChange.SetBool("fast", false);
                FindObjectOfType<Player>().GetComponent<Player>().notMove = false;
            }

        }
    }
    public void Respauwn()
    {
        //print("othia");
        pj.transform.position = Respaun;
        //print("FUNCIONA LA APOTEOSICA CONCHA DE TU MADREEEEE");
        if (vidas < 1)
        {
            pj.GetComponent<Player>().IsExternalForce = false;//anula fuerzas al hacer respawn

            intentos--;
            if (intentos < 0)//AQUI EDITAR COSAS PARA EL GAME OVER
            {
                //Application.LoadLevel(2);
                //SceneManager.LoadScene("Gameover");
                if (GameOver.GetCurrentAnimatorStateInfo(0).IsName("hide"))
                    LoseChange.Play("FastiHide");

                LoseChange.SetBool("fast", true);
                LoseChange.SetBool("show", true);

                GameOvers.SetActive(true);
                GameOver.SetTrigger("Trigger");
                FindObjectOfType<Menu>().GetComponent<Menu>().UIactivo = true;
                FindObjectOfType<contador>().GetComponent<contador>().onGame = true;
                
            }
            else
                vidas = 5;
        }
    }

    public void Tp(Vector3 land)
    {
        pj.transform.localPosition = land;
        //print("olas");
    }
    public void Start()
    {
        bigG = GameObject.FindGameObjectWithTag("Manager");
        bigG.GetComponent<grassTrigger>().activeGrass();
        print("GRASS POWER");
        //Modificar al incio!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        intentos = intentosStart;
        vidas = vidasStart;
        inmortals = false;
        //PlayerPrefs.DeleteAll();

        LoseChange = GameObject.FindGameObjectWithTag("LosChange").GetComponent<Animator>();
        GameOver = GameObject.FindGameObjectWithTag("GameOver").GetComponent<Animator>();
        GameOvers = GameObject.FindGameObjectWithTag("GameOver");

        GameOvers.SetActive(false);

        StartCoroutine(Light());
        key = 0;
        jumpKey = 0;

        foreach (GameObject i in startHide)
        {
            if (i != null)
            i.SetActive(false);
        }
    }
    IEnumerator Light()
    {
        yield return new WaitForSeconds(timer1);
        {
            if (camSun != null)
                camSun.SetActive(true);
            if (dungeon != null)
                dungeon.SetActive(false);
            //print("don't forget to enable this");
        }
    }
    public void DmgReciv()
    {
        gameObject.GetComponent<SfxManager>().Play("dmg");
    }
    public void Inmortal()
    {
        inmortals = true;
        Invoke("mortale", imortalTimer);
        Invoke("UnlockControls", unlockTimer);
        DmgReciv();

        //if (vidas < 1)
        {
            //Respauwn();

            //pj.GetComponent<Player>().IsExternalForce = false;//anula fuerzas al hacer respawn

            //FindObjectOfType<Player>().rb.constraints = RigidbodyConstraints.FreezePosition;

            //FindObjectOfType<Player>().rb.constraints = RigidbodyConstraints.None;
            //intentos--;
            //if(intentos < 0)
            {
                //Application.LoadLevel(2);
                //SceneManager.LoadScene("Gameover");
                    //LoseChange.Play("FastiHide");
                    //LoseChange.SetBool("fast", true);
                    //LoseChange.SetBool("show", true);

                    //GameOvers.SetActive(false);
                    //GameOver.SetTrigger("Trigger");

                //print("FUNCIONA LA APOTEOSICA CONCHA DE TU MADREEEEE");
            }
            //else
                //vidas = 5;
        }
    }
    public void mortale()
    {
        inmortals = false;
    }
    public void UnlockControls()
    {
        pj.GetComponent<Player>().IsExternalForce = false;
    }
    // Update is called once per frame
    void Update()
    {
        //PlayerPref 
        PlayerPrefs.SetInt("gb", Goblins);

        ResMon = Respaun;
        //ky = key;
        vd = vidas;
        inmorMonitor = inmortals;
        intent = intentos;

    }
}
