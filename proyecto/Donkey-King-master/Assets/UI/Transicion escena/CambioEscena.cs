using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;
    //Audio
    public AudioSource click;
    //Desaparecer
    public Scene scene;
    public string Exclude1;
    public string Exclude2;

    //CHANGE LEVEL
    public int sPivote;

    public void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name != Exclude1 & scene.name != Exclude2)
            StartCoroutine(disapear());
        print(scene.name);
    }
    IEnumerator disapear()
    {

        yield return new WaitForSeconds(2);

        gameObject.SetActive(false);
    }

    public void loadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        print("next level");
    }
    public void loadNexusLevel()
    {

        sPivote = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(LoadnLevel());

    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void loadMainMenu()
    {
        StartCoroutine(LoadMainMenu());
        print("next level");
    }

    IEnumerator LoadMainMenu()
    {
        transition.Play("change scene to black");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(0);
    }

    public void loadSelectLevel()
    {
        StartCoroutine(loadSelectionLevel());
    }

    IEnumerator loadSelectionLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(1);
    }

    public void loadFirstLevel()
    {
        click.Play();
        StartCoroutine(LoadnLevel());
        sPivote = 2;
    }
    public void loadSecondLevel()
    {
        click.Play();
        StartCoroutine(LoadnLevel());
        sPivote = 3;
    }
    public void loadThirdLevel()
    {
        click.Play();
        StartCoroutine(LoadnLevel());
        sPivote = 4;
    }
    public void loadFourthLevel()
    {
        click.Play();
        StartCoroutine(LoadnLevel());
        sPivote = 5;
    }
    public void loadFifthLevel()
    {
        click.Play();
        StartCoroutine(LoadnLevel());
        sPivote = 6;
    }

    IEnumerator LoadnLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sPivote);
    }
}
