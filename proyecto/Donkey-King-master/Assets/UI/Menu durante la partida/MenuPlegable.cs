using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPlegable : MonoBehaviour
{
    public GameObject SceneTrans;
    static public float mouseSensa = 0.5f;
    public float ResolutionMonitor;

    public Slider mySlider;
    public Slider mySlider2;
    public Slider mySlider3;

    static public int Resolution = 3;
    //Audio
    public AudioSource click;
    static public float Gvol = 0.5f;
    static public float SFX = 0.5f;


    private void Start()
    {
        if(PlayerPrefs.GetFloat("MouseSensal") < 1 | PlayerPrefs.GetFloat("MouseSensal") > 7)
            PlayerPrefs.SetFloat("MouseSensal", 3);

        if (PlayerPrefs.GetFloat("GlovalVol") < 0 | PlayerPrefs.GetFloat("GlovalVol") > 1)
            PlayerPrefs.SetFloat("GlovalVol", 0.5f);

        if (PlayerPrefs.GetFloat("GlovalSfx") < 0 | PlayerPrefs.GetFloat("GlovalSfx") > 3)
            PlayerPrefs.SetFloat("GlovalSfx", 1.5f);

        mySlider.value = PlayerPrefs.GetFloat("MouseSensal");
        mySlider2.value = PlayerPrefs.GetFloat("GlovalVol");
        mySlider3.value = PlayerPrefs.GetFloat("GlovalSfx");


    }
    private void Update()
    {
        ResolutionMonitor = PlayerPrefs.GetFloat("MouseSensal");
        //print(PlayerPrefs.GetFloat("MouseSensal"));
    }
    public void SetMouseSensibility (float mouseSensibility)
    {
        //FindObjectOfType<camera>().GetComponent<camera>().mouseSens = mouseSensibility;
        mouseSensa = mouseSensibility;
        PlayerPrefs.SetFloat("MouseSensal", mouseSensibility);
    }

    public void SetGblobalVolume(float globalVol)
    {
        //FindObjectOfType<camera>().GetComponent<camera>().mouseSens = mouseSensibility;
        Gvol = globalVol;
        PlayerPrefs.SetFloat("GlovalVol", globalVol);
        //MusicMaganer
        GameObject.FindGameObjectWithTag("MusicMaganer").GetComponent<AudioManager>().changeVol();
    }

    public void SetGblobalSfx(float globalSfx)
    {
        //FindObjectOfType<camera>().GetComponent<camera>().mouseSens = mouseSensibility;
        SFX = globalSfx;
        PlayerPrefs.SetFloat("GlovalSfx", globalSfx);
        if(GameObject.FindGameObjectWithTag("Manager") != null)
        GameObject.FindGameObjectWithTag("Manager").GetComponent<Menu>().SfxChange();
        if (GameObject.FindGameObjectWithTag("Wukong") != null)
            GameObject.FindGameObjectWithTag("Wukong").GetComponent<SfxManager>().VolChange();
    }

    public void GoToMenu()
    {
        FindObjectOfType<Menu>().GetComponent<Menu>().SceneChanger.SetActive(true);
        FindObjectOfType<CambioEscena>().GetComponent<CambioEscena>().loadMainMenu();
        Time.timeScale = 1.0f;
        click.Play();
    }

    public void GoToNext()
    {
        FindObjectOfType<Menu>().GetComponent<Menu>().SceneChanger.SetActive(true);
        FindObjectOfType<Menu>().GetComponent<Menu>().SceneChanger.GetComponent<Animator>().Play("change scene to black");
        FindObjectOfType<CambioEscena>().GetComponent<CambioEscena>().loadNextLevel();
        //SceneManager.LoadScene("Menú");
        click.Play();
    }
    public void GoToNexus()
    {
        FindObjectOfType<Menu>().GetComponent<Menu>().SceneChanger.SetActive(true);
        FindObjectOfType<Menu>().GetComponent<Menu>().SceneChanger.GetComponent<Animator>().Play("change scene to black");
        FindObjectOfType<CambioEscena>().GetComponent<CambioEscena>().loadNexusLevel();
        //SceneManager.LoadScene("Menú");
        click.Play();
    }

    public void MaxRend()
    {
        Resolution = 1;
        PlayerPrefs.SetInt("Resolutiion", 1);
        click.Play();

        //Ram
        if (GameObject.FindGameObjectWithTag("Manager") != null)
            FindObjectOfType<Menu>().GetComponent<Menu>().MaxRend();
    }
    public void MedRes()
    {
        Resolution = 2;
        PlayerPrefs.SetInt("Resolutiion", 2);
        click.Play();
        //Ram
        if (GameObject.FindGameObjectWithTag("Manager") != null)
            FindObjectOfType<Menu>().GetComponent<Menu>().MedRend();
    }
    public void MaxRes()
    {
        Resolution = 3;
        PlayerPrefs.SetInt("Resolutiion", 3);
        click.Play();
        //Ram
        if (GameObject.FindGameObjectWithTag("Manager") != null)
            FindObjectOfType<Menu>().GetComponent<Menu>().MinRend();
    }

}
