using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionJeuUI : MonoBehaviour
{

    // Gestionnaire d'onglet qui permet d'activer un UI à la fois
    public GestionnaireOnglet gestionnaireOnglet;
    // UI des options et de l'inventaire
    public GameObject canvasOption;
    public GameObject canvasInventaire;

    // Statut de si un UI est actif ou pas
    static public bool UIActif = false;
    // Start is called before the first frame update
    void Start()
    {

        // Aucun UI actif au début
        UIActif = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        

        // Si on appuie sur P et que le UI d'option est déjà ouvert
        if (Input.GetKeyDown(KeyCode.P) && canvasOption.activeSelf == true)
        {
            // Active le UI du curseur (le 0), et le reste se ferme automatiquement
            gestionnaireOnglet.activerOnglet(0);
            // Remet le curseur invisible
            CurseurInvisible();
        }
        // Si on appuie sur B et que le UI de l'inventaire est déjà ouvert
        else if (Input.GetKeyDown(KeyCode.B) && canvasInventaire.activeSelf == true)
        {
            // Active le UI du curseur (le 0), et le reste se ferme automatiquement
            gestionnaireOnglet.activerOnglet(0);
            // Remet le curseur invisible
            CurseurInvisible();
        }
        // Si on appuie sur P
        else if (Input.GetKeyDown(KeyCode.P)) {
            // Active le UI des options (1 dans le tableau dans le script GestionnaireOnglet)
            gestionnaireOnglet.activerOnglet(1);
            // Remet le curseur visible
            CurseurVisible(); 
        } 
        // Si on appuie sur B
        else if (Input.GetKeyDown(KeyCode.B)) {
            // Active le UI de l'inventaire (2 dans le tableau dans le script GestionnaireOnglet)
            gestionnaireOnglet.activerOnglet(2);
            // Remet le curseur visible
            CurseurVisible();
        }


        // Si le curseur est pas lock (Donc visible), UI actif est true car un UI est affiché
        if (Cursor.lockState == CursorLockMode.None) {
            UIActif = true;
        } 
        // Sinon c'est false car aucun UI n'est affiché si le curseur est lock (Donc invisible)
        else {
            UIActif = false;
        }


      
    }

    // Fonction qui rend le curseur visible et controlable
    void CurseurVisible()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    // Fonction qui rend le curseur invisible et incontrolable (Reste au milieu et invisible)
    void CurseurInvisible()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
