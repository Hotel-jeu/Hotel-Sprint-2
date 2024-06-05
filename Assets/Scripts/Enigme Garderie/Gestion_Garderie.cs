using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestion_Garderie : MonoBehaviour
{
    // Variables statiques pour suivre le nombre de diff�rences trouv�es et l'�tat de l'�nigme
    static public int differences_trouver = 0;
    static public bool enigme_fini = false;

    // Variable pour suivre le nombre d'erreurs commises
    public int erreurs_commises = 0;

    // R�f�rence au script Ennemi_Garderie_Malus
    public Ennemi_Garderie_Malus Ennemi_Garderie_Malus;

    // R�f�rence � l'ennemi de chasse
    public GameObject Ennemi_Chasse;

    // R�f�rences � l'ennemi et au joueur
    public GameObject Ennemi;
    public GameObject Joueur;

    void Update()
    {
        // V�rifie si toutes les diff�rences ont �t� trouv�es et si l'�nigme n'est pas encore termin�e
        if (differences_trouver == 7 && !enigme_fini)
        {
            // Marque l'�nigme comme termin�e
            enigme_fini = true;

            // D�sactive le comportement de l'ennemi malus
            Ennemi_Garderie_Malus.enabled = false;

            // Active la chasse apr�s un d�lai de 5 secondes
            Invoke("ActiverChasse", 5f);
        }

        // V�rifie si le nombre d'erreurs commises est �gal � 3
        if (erreurs_commises == 3)
        {
            // D�sactive le comportement de l'ennemi malus
            Ennemi_Garderie_Malus.enabled = false;

            // D�sactive le collider de l'ennemi, repositionne l'ennemi sur le joueur et r�active le collider
            Ennemi.GetComponent<Collider>().enabled = false;
            Ennemi.transform.position = Joueur.transform.position;
            Ennemi.GetComponent<Collider>().enabled = true;

            // R�initialise le compteur d'erreurs
            erreurs_commises = 0;
        }
    }

    // M�thode pour activer la chasse
    void ActiverChasse()
    {
        // Active l'ennemi de chasse et d�sactive l'ennemi original
        Ennemi_Chasse.SetActive(true);
        Ennemi.SetActive(false);
    }
}
