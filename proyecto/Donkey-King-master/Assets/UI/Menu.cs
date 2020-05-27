using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject terrenoCompleto;
    public GameObject terrenoVacio;
    public GameObject terrenoPlano;
    public GameObject walls;
    public GameObject UImenu;
    public bool UIactivo;
    public bool seguro;

    public GameObject SceneTrans;
    public bool Stadistics;
    public bool InDungeon;

    public int terrainQuality = 1;//1 = max, 2 = med, 3 = min//

    public List<GameObject> Ext;
    public GameObject SceneChanger;

    //RAM
    public List<GameObject> Decora;

    void Start()
    {
        SceneChanger = GameObject.FindGameObjectWithTag("scChanger");

        StartCoroutine(hideSceneTrans());
        SfxChange();

        if (PlayerPrefs.GetInt("Resolutiion") == 1)
            MaxRend();
        if (PlayerPrefs.GetInt("Resolutiion") == 2)
            MedRend();
        if (PlayerPrefs.GetInt("Resolutiion") == 3)
            MinRend();
    }
    public void MaxRend()
    {
        if (PlayerPrefs.GetInt("Resolutiion") == 1)
        {         //Ram
            foreach (GameObject ram in GameObject.FindGameObjectsWithTag("deco"))
            {
                Decora.Add(ram);
            }

            foreach (GameObject ran in Decora)
            {
                ran.SetActive(false);
            }
        }
    }
    public void MedRend()
    {
        if (PlayerPrefs.GetInt("Resolutiion") == 2)
        {         //Ram
            foreach (GameObject ram in GameObject.FindGameObjectsWithTag("deco"))
            {
                Decora.Add(ram);
            }

            foreach (GameObject ran in Decora)
            {
                ran.SetActive(true);
            }
        }
    }
    public void MinRend()
    {
        if (PlayerPrefs.GetInt("Resolutiion") == 3)
        {
            //Ram
            foreach (GameObject ram in GameObject.FindGameObjectsWithTag("deco"))
            {
                Decora.Add(ram);
            }

            foreach (GameObject ran in Decora)
            {
                ran.SetActive(true);
            }
        }
    }
    IEnumerator hideSceneTrans()
    {
        yield return new WaitForSeconds(1);
        SceneTrans.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Abrir menu
        if (Input.GetKeyDown(KeyCode.Escape) && Stadistics == false)
        {
            if (seguro == false & UIactivo == false)
            {
                seguro = true;
                UIactivo = true;
                UImenu.SetActive(true);
                Time.timeScale = 0f;
            }
            if (seguro == false & UIactivo == true)
            {
                seguro = true;
                UIactivo = false;
                UImenu.SetActive(false);
                Time.timeScale = 1.0f;
            }
            seguro = false;
        }
        //Cursor
        if (UIactivo == true)
            Cursor.visible = true;
        if (UIactivo == false)
            Cursor.visible = false;
        //Calidad del terreno
        if(InDungeon == false)
        {
            if (PlayerPrefs.GetInt("Resolutiion") == 3)
            {
                terrainQuality = 1;
                terrenoCompleto.SetActive(true);
                terrenoVacio.SetActive(false);
                terrenoPlano.SetActive(false);
                if (PlayerPrefs.GetInt("planta") == 0)
                    walls.SetActive(true);
            }
            if (PlayerPrefs.GetInt("Resolutiion") == 2)
            {
                terrainQuality = 2;
                terrenoCompleto.SetActive(false);
                terrenoVacio.SetActive(true);
                terrenoPlano.SetActive(false);
                if (PlayerPrefs.GetInt("planta") == 0)
                    walls.SetActive(true);
            }
            if (PlayerPrefs.GetInt("Resolutiion") == 1)
            {
                terrainQuality = 3;
                terrenoCompleto.SetActive(false);
                terrenoVacio.SetActive(false);
                terrenoPlano.SetActive(true);
                walls.SetActive(false);
            }
        }
        
    }

    public void SfxChange()
    {
        //MusicMaganer
        //GameObject.FindGameObjectWithTag("MusicMaganer").GetComponent<AudioManager>().changeVol();
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Sfx"))
        {
            if(Ext != null)
            Ext.Add(fooObj);
        }

        foreach (GameObject sfx in Ext)
        {
            if (sfx != null)
                if (sfx.GetComponent<SfxManager>() != null)
                    sfx.GetComponent<SfxManager>().VolChange();
        }
    }
}
