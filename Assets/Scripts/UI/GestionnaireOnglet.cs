using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestionnaireOnglet : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] lesOnglets;


    void Start()
    {
        activerOnglet(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void activerOnglet(int indexOngletActif) {
        if (indexOngletActif < 0 || indexOngletActif >= lesOnglets.Length) {
            return;
        }
        foreach (GameObject onglet in lesOnglets)
       {
    onglet.SetActive(false);
    }

    lesOnglets[indexOngletActif].SetActive(true);
    }



    public void CurseurInvisible() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
