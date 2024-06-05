using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionEnigmeBiblio : MonoBehaviour
{
    // Variable statique qui determine combien de photos ont ete trouver
    static public int Nbr_Photos_Trouver = 0;
    // Variable statique qui determine si l'enigme de la bibliotheque est fini
    static public bool Enigme_Biblio_Fini = false;
    // Variable booelenne afin de ne lancer le code qu'une fois
    private bool Enigme_Fini = false;

    public GameObject GestionnaireCamera;
    // Animator de la camera qui montre les photos
    public Animator Camera_Photo;
    // Porte de sortie de la bibliotheque
    public GameObject Porte_Sortie;


    private void Update() {
        // Si le joueur a trouver les 5 photos, et que les deux variable qui determine la fin de lenigme sont false
        if (Nbr_Photos_Trouver == 5 && !Enigme_Fini && !Enigme_Biblio_Fini)
        {
            // Les met a true afin d'eviter de relancer le code
            Enigme_Fini = true;
            Enigme_Biblio_Fini = true;
            // Active la camera de photo, et son animation
            GestionnaireCamera.GetComponent<GestionnaireCamera>().ActiveCam(1);
            Camera_Photo.SetBool("activerCam", true);
            // Active la camera qui montre la porte de sortie apres 2.5 secondes
            Invoke("Montre_Camera_Porte_Sortie", 2.5f);

        } 
        // Si le joueur a trouver les 5 photos, mais que c'est la deuxieme fois que ce code se lance
        else if (Nbr_Photos_Trouver == 5 && !Enigme_Fini) {
            // Active directement la camera qui montre la porte de sortie
            Montre_Camera_Porte_Sortie();
            // Et met cette variable a true afin d'eviter de lancer le code 2 fois
            Enigme_Fini = true;
        }
    }

    private void Montre_Camera_Porte_Sortie() {
        // Active la camera de la porte de sortie
        GestionnaireCamera.GetComponent<GestionnaireCamera>().ActiveCam(3);
        // Ouvre la porte de sortie, et active son Audio Source
        Porte_Sortie.GetComponent<Animator>().SetBool("porteOuvert", true);
        Porte_Sortie.GetComponent<AudioSource>().enabled = true;
        // Remettre la camera normale apres 1.5 secondes
        Invoke("Remettre_Camera_Normale", 1.5f);
    }

    private void Remettre_Camera_Normale() {
        GestionnaireCamera.GetComponent<GestionnaireCamera>().ActiveCam(0);
    }
}
