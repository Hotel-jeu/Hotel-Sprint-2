using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debut_Enigme1 : MonoBehaviour
{
    // R�f�rence � l'objet barri�re de l'ascenseur
    public GameObject BarriereAscenseur;

    // R�f�rence � l'objet de chargement de la sc�ne de fin
    public GameObject ChargementScene_Fin;

    // Bool�en statique pour v�rifier si l'�nigme a d�j� �t� lanc�e
    static public bool deja_lancer = false;

    void Update()
    {
        // Si l'audio est activ� mais ne joue pas, d�sactiver l'objet
        if (GetComponent<AudioSource>().enabled && !GetComponent<AudioSource>().isPlaying)
        {
            deja_lancer = true;
            gameObject.SetActive(false);
        }

        // Si l'�nigme a �t� lanc�e et toutes les conditions sont remplies
        if (deja_lancer && gestionEnigmeBiblio.Enigme_Biblio_Fini && Gestion_Garderie.enigme_fini)
        {
            // Activer la sc�ne de fin et d�sactiver l'objet actuel
            ChargementScene_Fin.SetActive(true);
            gameObject.SetActive(false);
        }
        else if (deja_lancer)
        {
            // Fermer la barri�re de l'ascenseur, activer la sc�ne de fin et d�sactiver l'objet actuel
            BarriereAscenseur.GetComponent<Animator>().SetBool("FermerGate", true);
            ChargementScene_Fin.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    // M�thode appel�e quand un autre objet entre dans le trigger
    void OnTriggerEnter(Collider collider)
    {
        // Si l'objet est le joueur et que l'audio n'est pas activ�
        if (collider.gameObject.CompareTag("player") && !GetComponent<AudioSource>().enabled)
        {
            // Activer l'audio, fermer la barri�re de l'ascenseur et activer la sc�ne de fin
            GetComponent<AudioSource>().enabled = true;
            BarriereAscenseur.GetComponent<Animator>().SetBool("FermerGate", true);
            ChargementScene_Fin.SetActive(true);
            // D�sactiver le collider de l'objet actuel
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
