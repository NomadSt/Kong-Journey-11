using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text GolDragon;

    public Animator LoseChange;
    public GameObject pej;
    public GameObject GameOvers;

    void Start()
    {
        LoseChange = GameObject.FindGameObjectWithTag("LosChange").GetComponent<Animator>();
        GameOvers = GameObject.FindGameObjectWithTag("GameOver");
    }
    public void toMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Revivir()
    {
        if(PlayerPrefs.GetInt("GolDragon") >= 5)
        {
            FindObjectOfType<Estadísticas>().GetComponent<Estadísticas>().trapecista = true;
            FindObjectOfType<Estadísticas>().GetComponent<Estadísticas>().inmortal = true;
            PlayerPrefs.SetInt("GolDragon", PlayerPrefs.GetInt("GolDragon") - 5);
            pej = GameObject.FindGameObjectWithTag("Wukong");
            pej.GetComponent<Player>().CanaMove();
            LoseChange.SetBool("show", false);
            LoseChange.SetBool("fast", false);
            FindObjectOfType<BaseCam>().GetComponent<BaseCam>().enabled = true;
            FindObjectOfType<Player>().GetComponent<Player>().notMove = false;
            pej.GetComponent<Player>().notMove = true;
            Animation1.intentos = 5;
            Animation1.vidas = 5;
            Animation1.inmortals = false;
            GameOvers.SetActive(false);
            FindObjectOfType<Menu>().GetComponent<Menu>().UIactivo = false;
            FindObjectOfType<contador>().GetComponent<contador>().onGame = false;
            FindObjectOfType<contador>().GetComponent<contador>().Times();
        }
    }
    public void Update()
    {
        GolDragon.text = PlayerPrefs.GetInt("GolDragon").ToString();
        if (Input.GetKey(KeyCode.M))
        {
            PlayerPrefs.SetInt("GolDragon", PlayerPrefs.GetInt("GolDragon") + 1);
        }
    }
}
