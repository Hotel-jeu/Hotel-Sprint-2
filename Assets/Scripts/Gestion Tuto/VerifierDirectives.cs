using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifierDirectives : MonoBehaviour
{
    // Références aux anciens et nouveaux textes
    public GameObject AncienTexte;
    public GameObject NouveauTexte;

    // Clip audio pour le dialogue
    public AudioClip SonDialogue;

    // Méthode appelée quand un autre objet entre dans le trigger
    void OnTriggerEnter(Collider collider)
    {
        // Si l'objet est le joueur
        if (collider.gameObject.CompareTag("player"))
        {
            // Désactiver l'ancien texte et activer le nouveau texte
            AncienTexte.SetActive(false);
            NouveauTexte.SetActive(true);

            // Si un son de dialogue est défini, le jouer
            if (SonDialogue != null)
            {
                GetComponent<AudioSource>().PlayOneShot(SonDialogue);
                // Détruire le nouveau texte après 3 secondes
                Destroy(NouveauTexte, 3f);
            }

            // Désactiver le collider pour éviter de réactiver le trigger
            GetComponent<Collider>().enabled = false;
        }
    }
}
