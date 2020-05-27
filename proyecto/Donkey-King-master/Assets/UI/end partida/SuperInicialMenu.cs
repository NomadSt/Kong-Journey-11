using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuperInicialMenu : MonoBehaviour
{
    public GameObject MenuMenu;
    public GameObject[] Menubuttons;
    public GameObject SceneChanger;

    //Audio
    public AudioSource click;

    public void Start()
    {
        SceneChanger = GameObject.FindGameObjectWithTag("scChanger");
    }
    public void Starto()
    {
        SceneChanger.SetActive(true);
        //SceneManager.LoadScene("Fix rotate");
        FindObjectOfType<CambioEscena>().GetComponent<CambioEscena>().loadSelectLevel();
        print("starto");
        click.Play();
    }

    public void Exit()
    {
        Application.Quit();
        click.Play();
    }

    public void OpenMenu()
    {
        MenuMenu.SetActive(true);
        click.Play();

        foreach (GameObject i in Menubuttons)
        {
            i.SetActive(false);
        }

    }
    public void CloseMenu()
    {
        click.Play();
        MenuMenu.SetActive(false);

        foreach (GameObject i in Menubuttons)
        {
            i.SetActive(true);
        }
    }
}
