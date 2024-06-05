using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debut_Enigme1 : MonoBehaviour
{
    // Référence à l'objet barrière de l'ascenseur
    public GameObject BarriereAscenseur;

    // Référence à l'objet de chargement de la scène de fin
    public GameObject ChargementScene_Fin;

    // Booléen statique pour vérifier si l'énigme a déjà été lancée
    static public bool deja_lancer = false;

    void Update()
    {
        // Si l'audio est activé mais ne joue pas, désactiver l'objet
        if (GetComponent<AudioSource>().enabled && !GetComponent<AudioSource>().isPlaying)
        {
            deja_lancer = true;
            gameObject.SetActive(false);
        }

        // Si l'énigme a été lancée et toutes les conditions sont remplies
        if (deja_lancer && gestionEnigmeBiblio.Enigme_Biblio_Fini && Gestion_Garderie.enigme_fini)
        {
            // Activer la scène de fin et désactiver l'objet actuel
            ChargementScene_Fin.SetActive(true);
            gameObject.SetActive(false);
        }
        else if (deja_lancer)
        {
            // Fermer la barrière de l'ascenseur, activer la scène de fin et désactiver l'objet actuel
            BarriereAscenseur.GetComponent<Animator>().SetBool("FermerGate", true);
            ChargementScene_Fin.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    // Méthode appelée quand un autre objet entre dans le trigger
    void OnTriggerEnter(Collider collider)
    {
        // Si l'objet est le joueur et que l'audio n'est pas activé
        if (collider.gameObject.CompareTag("player") && !GetComponent<AudioSource>().enabled)
        {
            // Activer l'audio, fermer la barrière de l'ascenseur et activer la scène de fin
            GetComponent<AudioSource>().enabled = true;
            BarriereAscenseur.GetComponent<Animator>().SetBool("FermerGate", true);
            ChargementScene_Fin.SetActive(true);
            // Désactiver le collider de l'objet actuel
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
