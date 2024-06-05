using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionEnigme2 : MonoBehaviour
{
    // Pointage caché qui sert à savoir si le joueur a trouvé les 6 codes ou pas
    static public float codesTrouver = 0;
    // L'ascenseur de sortie
    public GameObject ascenseurSortie;
    // Le gestionnaire de caméra pour activer la caméra qui montre l'ascenseur une fois qu'il a trouvé les 6
    public GameObject GestionnaireCamera;
    // Regarde si l'énigme est fini ou pas
    private bool enigmeFini = false;
    // Son de l'ouverture de l'ascenseur
    public AudioClip sonOuvertureAscenseur;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        // Si il a trouvé les 6 codes et que l'énigme n'est pas toujours fini
        if (codesTrouver == 6 && !enigmeFini) {

            // Activer la musique de l'ascenseur
            ascenseurSortie.GetComponent<AudioSource>().enabled = true;
            // Mettre le son d'ouverture de l'ascenseur
            GetComponent<AudioSource>().PlayOneShot(sonOuvertureAscenseur);
            // Active l'animation d'ouverture de l'ascenseur
            ascenseurSortie.GetComponent<Animator>().SetBool("ouvrirAscenseur", true);

            // Active la caméra qui montre l'ouverture de l'ascenseur
            GestionnaireCamera.GetComponent<GestionnaireCamera>().ActiveCam(1);
            // Fini l'énigme
            enigmeFini = true;
            // Remet la caméra normal après 1.5 seconde
            Invoke("ReactiverCamJoueur", 1.5f);
        }
    }

    // Utilise le gestionnaire de caméra pour remettre la caméra normal ( Le 0 )
    void ReactiverCamJoueur() {

        GestionnaireCamera.GetComponent<GestionnaireCamera>().ActiveCam(0);
    }
}
