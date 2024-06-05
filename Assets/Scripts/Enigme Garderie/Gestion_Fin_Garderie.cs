using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gestion_Fin_Garderie : MonoBehaviour
{
    // Référence au GameObject affichant le message pour courir
    public GameObject Courir_Message;

    // Référence au gestionnaire de caméra
    public GestionnaireCamera GestionnaireCamera;

    // Références aux portes de la salle et de la garderie
    public GameObject PorteSalle;
    public GameObject PorteGarderie;

    // Référence à la source audio pour la musique de la garderie
    public AudioSource Musique_Garderie;

    // Variable pour vérifier si l'activation a été faite
    private bool une_activation = false;

    // Méthode appelée au démarrage du script
    void Start()
    {
        // Désactive le message pour courir au début
        Courir_Message.SetActive(false);
    }

    void Update()
    {
        // Vérifie si l'énigme est terminée et si l'activation n'a pas encore été faite
        if (Gestion_Garderie.enigme_fini && !une_activation)
        {
            // Marque l'activation comme faite
            une_activation = true;

            // Affiche le message pour courir
            Courir_Message.SetActive(true);

            // Active la caméra 1
            GestionnaireCamera.ActiveCam(1);

            // Ouvre la porte de la salle
            PorteSalle.GetComponent<Animator>().SetBool("porteOuvert", true);

            // Active l'animation et le son de la porte de la garderie
            PorteGarderie.GetComponent<Animator>().enabled = true;
            PorteGarderie.GetComponent<AudioSource>().enabled = true;

            // Arrête la musique de la garderie
            Musique_Garderie.Stop();

            // Active la source audio attachée à ce GameObject
            GetComponent<AudioSource>().enabled = true;

            // Désactive le message et réactive la caméra principale après 3 secondes
            Invoke("Desactiver_Message_Camera", 3f);
        }
    }

    // Méthode pour désactiver le message et réactiver la caméra principale
    void Desactiver_Message_Camera()
    {
        // Active la caméra principale (caméra 0)
        GestionnaireCamera.ActiveCam(0);

        // Désactive le message pour courir
        Courir_Message.SetActive(false);
    }
}
