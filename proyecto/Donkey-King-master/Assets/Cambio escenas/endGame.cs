using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{
    public Dialogos Dialogo;//asignar script a trigger
    public Dialogos[] hijo;
    public int wisem;
    public GameObject contador;
    public GameObject Player;

    public GameObject Estadisticas;//Objeto UI estadistica
    // Start is called before the first frame update
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogManager>().StartDialogue(hijo[wisem]);//permite almacenar varias posibilidades de diálogo dentro de un mismo objeto, usando la misma pauta
        FindObjectOfType<DialogManager>().budaTalks = true;
        if (GameObject.FindGameObjectWithTag("LosChange") != null)
            GameObject.FindGameObjectWithTag("LosChange").SetActive(false);
        //FindObjectOfType<DialogManager>().StartDialogue(Dialogo);//permite acceder al dialogo único almacenado en el personaje
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            contador.GetComponent<contador>().onGame = true;
            wisem = Random.Range(0, hijo.Length-1);
            TriggerDialogue();
            FindObjectOfType<Player>().GetComponent<Player>().notMove = true;
            Player = GameObject.FindGameObjectWithTag("Wukong");
            Player.GetComponent<SfxManager>().Play("buda");
        }
    }
    // Update is called once per frame
    public void EndGame()
    {
        //SceneManager.LoadScene("Estadisticas");
        Estadisticas.SetActive(true);
        Estadisticas.GetComponent<Estadísticas>().Appear();


    }
}
