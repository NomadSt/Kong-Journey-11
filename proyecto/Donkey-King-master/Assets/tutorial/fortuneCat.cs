using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fortuneCat : MonoBehaviour
{
    public GameObject pej;
    public Vector3 Look;
    public GameObject DialogMAnager;

    public Dialogos oraciones;

    public float tolerancia = 5.0f;
    public float tol;
    public Vector3 dits;
    public bool used;//impide bug, cancelar dialogo de otra instancia
    //public int wisem;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Look = new Vector3(FindObjectOfType<Player>().transform.position.x,transform.position.y, FindObjectOfType<Player>().transform.position.z);
        transform.LookAt(Look);

        //Si se aleja mucho, detener dialogo
        pej = GameObject.FindGameObjectWithTag("Wukong");
        if (pej != null)
            dits = transform.position - pej.transform.position;

        tol = dits.magnitude;

        if (tol > tolerancia & used == false)
        {
            FindObjectOfType<dialogTutorial>().EndDialogue();
            used = true;
        }
    }

    public void TriggerDialogue()
    {
        //DialogMAnager.GetComponent<dialogTutorial>().StartDialogue(oraciones);//permite almacenar varias posibilidades de diálogo dentro de un mismo objeto, usando la misma pauta
        FindObjectOfType<dialogTutorial>().StartDialogue(oraciones);
    }
    public void TriggerDialogueEgg()
    {
        //DialogMAnager.GetComponent<dialogTutorial>().StartDialogue(oraciones);//permite almacenar varias posibilidades de diálogo dentro de un mismo objeto, usando la misma pauta
        FindObjectOfType<dialogTutorial>().StartDialogue(oraciones);
        FindObjectOfType<dialogTutorial>().EggTrue();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //TriggerDialogue();
        }
    }
}
