using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiodepantala1 : MonoBehaviour
{
    // Start is called before the first frame update
    public void next()
    {
        PlayerPrefs.DeleteAll();
        Application.LoadLevel(1);
    }

}
