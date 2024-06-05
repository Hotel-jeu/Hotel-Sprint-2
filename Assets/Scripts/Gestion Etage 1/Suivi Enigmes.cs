using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuiviEnigmes : MonoBehaviour
{
    // Variables pour suivre l'état des énigmes
    public bool Enigme_Etage1_Fini = false;

    // Références aux objets de l'ascenseur et barrières
    public GameObject Ascenseur;
    public GameObject BarriereAscenseur;
    public GameObject BarriereGarderie;
    public GameObject BarriereBiblio;

    // Variables statiques pour vérifier si le son des barrières a été joué
    static public bool Son_Barriere_Biblio_Fait = false;
    static public bool Son_Barriere_Garderie_Fait = false;

    void Start()
    {
        // Ouvrir l'ascenseur et la barrière de l'ascenseur au début
        Ascenseur.GetComponent<Animator>().SetBool("ouvrirAscenseur", true);
        BarriereAscenseur.GetComponent<Animator>().SetBool("OuvrirGate", true);
    }

    void Update()
    {
        // Si les énigmes de la bibliothèque et de la garderie sont terminées et que l'étage 1 n'est pas encore fini
        if (gestionEnigmeBiblio.Enigme_Biblio_Fini && Gestion_Garderie.enigme_fini && !Enigme_Etage1_Fini)
        {
            // Marquer l'étage 1 comme terminé et ouvrir la barrière de l'ascenseur
            Enigme_Etage1_Fini = true;
            BarriereAscenseur.GetComponent<Animator>().SetBool("OuvrirGate", true);
        }

        // Si l'énigme de la bibliothèque est terminée
        if (gestionEnigmeBiblio.Enigme_Biblio_Fini)
        {
            // Activer l'animation de la barrière de la bibliothèque
            BarriereBiblio.GetComponent<Animator>().enabled = true;
            // Si le son de la barrière n'a pas encore été joué, l'activer
            if (!Son_Barriere_Biblio_Fait)
            {
                BarriereBiblio.GetComponent<AudioSource>().enabled = true;
                Son_Barriere_Biblio_Fait = true;
            }
        }

        // Si l'énigme de la garderie est terminée
        if (Gestion_Garderie.enigme_fini)
        {
            // Activer l'animation de la barrière de la garderie
            BarriereGarderie.GetComponent<Animator>().enabled = true;
            // Si le son de la barrière n'a pas encore été joué, l'activer
            if (!Son_Barriere_Garderie_Fait)
            {
                BarriereGarderie.GetComponent<AudioSource>().enabled = true;
                Son_Barriere_Garderie_Fait = true;
            }
        }
    }
}
