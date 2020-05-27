using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dialogTutorial : MonoBehaviour
{
    private Queue<string> oraciones;//asignar script a objeto manager

    public Text Nombre;
    public Text cuerpo;
    public Animator cuadro;
    public GameObject square;
    public Animator drama;

    public GameObject cam;
    public GameObject[] Instancias;//Almacena gatos que ya finalizaron dialogos para que no interfieran en los nuevos (por la distancia cancelen dialogo)
                                   // Start is called before the first frame update

    public bool egg;//easter egg
    public GameObject f1;
    public GameObject f2;
    public GameObject f3;
    public GameObject f4;

    public int cambioA;
    public int cambioB;
    public int cambioC;
    public int pivote;

    void Start()
    {
        oraciones = new Queue<string>();
    }
    public void EggTrue()
    {
        egg = true;
    }
    public void StartDialogue(Dialogos dialogo)
    {
        cuadro.SetBool("IsOpen", true);
        drama.SetBool("IsDialog", true);
        Nombre.text = dialogo.Name;


        oraciones.Clear();
        foreach (string sentence in dialogo.oracion)
        {
            oraciones.Enqueue(sentence);
        }

        NextSentence();

    }

    public void NextSentence()
    {
        if (GetComponent<DialogManager>().budaTalks == false)
        {
            if (oraciones.Count == 0)
            {
                EndDialogue();
                return;
            }
            string sentence = oraciones.Dequeue();
            //cuerpo.text = sentence;

            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
    }
    IEnumerator TypeSentence(string sentence)
    {
        if (GetComponent<DialogManager>().budaTalks == false)
        {
            cuerpo.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                cuerpo.text += letter;
                yield return null;//espera un frame y permite funcionar a corrutina
            }
        }
    }
    public void EndDialogue()
    {
        if (GetComponent<DialogManager>().budaTalks == false)
        {

            cuadro.SetBool("IsOpen", false);
            drama.SetBool("IsDialog", false);
            FindObjectOfType<BaseCam>().GetComponent<BaseCam>().esInteres = false;
            Instancias = GameObject.FindGameObjectsWithTag("catFortune");
            foreach (GameObject i in Instancias)
            {
                i.GetComponent<fortuneCat>().used = true;
            }
            //EasterEgg
            if (egg & pivote >= cambioC)
            {
                egg = false;
                f4.SetActive(false);
                FindObjectOfType<Player>().GetComponent<Player>().notMove = false;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) & GetComponent<DialogManager>().budaTalks == false)
        {
            NextSentence();
            if (egg)
            {
                pivote++;
                if(pivote == cambioA)
                {
                    f1.SetActive(false);
                    f2.SetActive(true);
                }
                if (pivote == cambioB)
                {
                    f2.SetActive(false);
                    f3.SetActive(true);
                }
                if (pivote == cambioC)
                {
                    f3.SetActive(false);
                    f4.SetActive(true);
                }
            }
        }
    }
}
