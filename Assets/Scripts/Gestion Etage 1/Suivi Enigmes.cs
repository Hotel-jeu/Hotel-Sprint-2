using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuiviEnigmes : MonoBehaviour
{
    // Variables pour suivre l'�tat des �nigmes
    public bool Enigme_Etage1_Fini = false;

    // R�f�rences aux objets de l'ascenseur et barri�res
    public GameObject Ascenseur;
    public GameObject BarriereAscenseur;
    public GameObject BarriereGarderie;
    public GameObject BarriereBiblio;

    // Variables statiques pour v�rifier si le son des barri�res a �t� jou�
    static public bool Son_Barriere_Biblio_Fait = false;
    static public bool Son_Barriere_Garderie_Fait = false;

    void Start()
    {
        // Ouvrir l'ascenseur et la barri�re de l'ascenseur au d�but
        Ascenseur.GetComponent<Animator>().SetBool("ouvrirAscenseur", true);
        BarriereAscenseur.GetComponent<Animator>().SetBool("OuvrirGate", true);
    }

    void Update()
    {
        // Si les �nigmes de la biblioth�que et de la garderie sont termin�es et que l'�tage 1 n'est pas encore fini
        if (gestionEnigmeBiblio.Enigme_Biblio_Fini && Gestion_Garderie.enigme_fini && !Enigme_Etage1_Fini)
        {
            // Marquer l'�tage 1 comme termin� et ouvrir la barri�re de l'ascenseur
            Enigme_Etage1_Fini = true;
            BarriereAscenseur.GetComponent<Animator>().SetBool("OuvrirGate", true);
        }

        // Si l'�nigme de la biblioth�que est termin�e
        if (gestionEnigmeBiblio.Enigme_Biblio_Fini)
        {
            // Activer l'animation de la barri�re de la biblioth�que
            BarriereBiblio.GetComponent<Animator>().enabled = true;
            // Si le son de la barri�re n'a pas encore �t� jou�, l'activer
            if (!Son_Barriere_Biblio_Fait)
            {
                BarriereBiblio.GetComponent<AudioSource>().enabled = true;
                Son_Barriere_Biblio_Fait = true;
            }
        }

        // Si l'�nigme de la garderie est termin�e
        if (Gestion_Garderie.enigme_fini)
        {
            // Activer l'animation de la barri�re de la garderie
            BarriereGarderie.GetComponent<Animator>().enabled = true;
            // Si le son de la barri�re n'a pas encore �t� jou�, l'activer
            if (!Son_Barriere_Garderie_Fait)
            {
                BarriereGarderie.GetComponent<AudioSource>().enabled = true;
                Son_Barriere_Garderie_Fait = true;
            }
        }
    }
}
