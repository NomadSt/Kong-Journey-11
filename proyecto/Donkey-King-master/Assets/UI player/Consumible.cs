using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI;

public class Consumible : MonoBehaviour
{
    public GameObject pej;
    public Vector3 distancia3d;
    public float distancia;
    public float tolerancia;

    public int tipo;//1;rice 2; intentos; 3.4.5 easter Egg; 6 Golden dragon
    public Animator EGG;
    public Text textChange;

    public GameObject contadore;//estadistica
    public Text GolDragon1;

    public bool taken;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (taken == false)
        {
            if (other.tag == "Player")
            {
                taken = true;
                if (tipo == 1)
                {
                    
                    contadore = GameObject.FindGameObjectWithTag("Manager");//estadistica
                    FindObjectOfType<contador>().rice++;
                    GameObject.FindGameObjectWithTag("Wukong").GetComponent<SfxManager>().Play("rice");
                    Destroy(this.gameObject);
                    PlayerPrefs.SetInt("arrzoi", PlayerPrefs.GetInt("arrzoi") + 1);
                    if (Animation1.vidas < 5)
                        Animation1.vidas += 1;
                    //print(GameObject.FindGameObjectWithTag("Manager").GetComponent<contador>().rice);
                }
                if (tipo == 2)
                {
                    contadore = GameObject.FindGameObjectWithTag("Manager");//estadistica
                    FindObjectOfType<contador>().jade++;
                    GameObject.FindGameObjectWithTag("Wukong").GetComponent<SfxManager>().Play("jade");
                    PlayerPrefs.SetInt("intent", PlayerPrefs.GetInt("intent") + 1);
                    Destroy(this.gameObject);
                    Animation1.intentos += 1;
                    print(GameObject.FindGameObjectWithTag("Manager").GetComponent<contador>().jade);
                }
                if (tipo == 3)
                {
                    GameObject.FindGameObjectWithTag("Wukong").GetComponent<SfxManager>().Play("gems");
                    FindObjectOfType<contador>().p1 = true;
                    Destroy(this.gameObject);
                    EGG.SetBool("expuesto", true);
                    FindObjectOfType<contador>().corrutinaEasterEgg(EGG);
                    textChange.text = "1/3";
                }
                if (tipo == 4)
                {
                    GameObject.FindGameObjectWithTag("Wukong").GetComponent<SfxManager>().Play("gems");
                    FindObjectOfType<contador>().p2 = true;
                    Destroy(this.gameObject);
                    EGG.SetBool("expuesto", true);
                    FindObjectOfType<contador>().corrutinaEasterEgg(EGG);
                    textChange.text = "2/3";
                }
                if (tipo == 5)
                {
                    GameObject.FindGameObjectWithTag("Wukong").GetComponent<SfxManager>().Play("gems");
                    FindObjectOfType<contador>().p3 = true;
                    Destroy(this.gameObject);
                    EGG.SetBool("expuesto", true);
                    FindObjectOfType<contador>().corrutinaEasterEgg(EGG);
                    textChange.text = "3/3";
                    if (FindObjectOfType<contador>().p2 == true & FindObjectOfType<contador>().p1 == true)
                    {
                        FindObjectOfType<contador>().EggBreack();
                        FindObjectOfType<Player>().GetComponent<Player>().notMove = true;
                    }
                }
                if (tipo == 6)
                {
                    GameObject.FindGameObjectWithTag("Wukong").GetComponent<SfxManager>().Play("gems");
                    GameObject.FindGameObjectWithTag("goldenDragon").GetComponent<Animator>().SetTrigger("gold");
                    PlayerPrefs.SetInt("GolDragon", PlayerPrefs.GetInt("GolDragon") + 1);
                    //gdtext
                    GolDragon1 = GameObject.FindGameObjectWithTag("gdtext").GetComponent<Text>();
                    GolDragon1.text = PlayerPrefs.GetInt("GolDragon").ToString();
                    Destroy(this.gameObject);
                }
            }
        }
        
    }
    
}
