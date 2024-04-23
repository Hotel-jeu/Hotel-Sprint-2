using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionJeuUI : MonoBehaviour
{

    public GestionnaireOnglet gestionnaireOnglet;

    public GameObject canvasOption;
    public GameObject canvasInventaire;

    static public bool UIActif = false;
    // Start is called before the first frame update
    void Start()
    {
        UIActif = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && canvasOption.activeSelf == true)
        {
            gestionnaireOnglet.activerOnglet(0);
            CurseurInvisible();
        }

        else if (Input.GetKeyDown(KeyCode.B) && canvasInventaire.activeSelf == true)
        {
            gestionnaireOnglet.activerOnglet(0);
            CurseurInvisible();
        }
        else if (Input.GetKeyDown(KeyCode.P)) {
            gestionnaireOnglet.activerOnglet(1);
            CurseurVisible(); 
        } 
        else if (Input.GetKeyDown(KeyCode.B)) {
            gestionnaireOnglet.activerOnglet(2);
            CurseurVisible();
        }



        if (Cursor.lockState == CursorLockMode.None) {
            UIActif = true;
        } else {
            UIActif = false;
        }


      
    }

    void CurseurVisible()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void CurseurInvisible()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
