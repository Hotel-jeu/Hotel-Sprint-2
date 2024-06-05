using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifierDirectives : MonoBehaviour
{
    // R�f�rences aux anciens et nouveaux textes
    public GameObject AncienTexte;
    public GameObject NouveauTexte;

    // Clip audio pour le dialogue
    public AudioClip SonDialogue;

    // M�thode appel�e quand un autre objet entre dans le trigger
    void OnTriggerEnter(Collider collider)
    {
        // Si l'objet est le joueur
        if (collider.gameObject.CompareTag("player"))
        {
            // D�sactiver l'ancien texte et activer le nouveau texte
            AncienTexte.SetActive(false);
            NouveauTexte.SetActive(true);

            // Si un son de dialogue est d�fini, le jouer
            if (SonDialogue != null)
            {
                GetComponent<AudioSource>().PlayOneShot(SonDialogue);
                // D�truire le nouveau texte apr�s 3 secondes
                Destroy(NouveauTexte, 3f);
            }

            // D�sactiver le collider pour �viter de r�activer le trigger
            GetComponent<Collider>().enabled = false;
        }
    }
}
