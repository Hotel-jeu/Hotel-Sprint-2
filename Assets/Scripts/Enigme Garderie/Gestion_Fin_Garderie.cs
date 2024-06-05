using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gestion_Fin_Garderie : MonoBehaviour
{
    // R�f�rence au GameObject affichant le message pour courir
    public GameObject Courir_Message;

    // R�f�rence au gestionnaire de cam�ra
    public GestionnaireCamera GestionnaireCamera;

    // R�f�rences aux portes de la salle et de la garderie
    public GameObject PorteSalle;
    public GameObject PorteGarderie;

    // R�f�rence � la source audio pour la musique de la garderie
    public AudioSource Musique_Garderie;

    // Variable pour v�rifier si l'activation a �t� faite
    private bool une_activation = false;

    // M�thode appel�e au d�marrage du script
    void Start()
    {
        // D�sactive le message pour courir au d�but
        Courir_Message.SetActive(false);
    }

    void Update()
    {
        // V�rifie si l'�nigme est termin�e et si l'activation n'a pas encore �t� faite
        if (Gestion_Garderie.enigme_fini && !une_activation)
        {
            // Marque l'activation comme faite
            une_activation = true;

            // Affiche le message pour courir
            Courir_Message.SetActive(true);

            // Active la cam�ra 1
            GestionnaireCamera.ActiveCam(1);

            // Ouvre la porte de la salle
            PorteSalle.GetComponent<Animator>().SetBool("porteOuvert", true);

            // Active l'animation et le son de la porte de la garderie
            PorteGarderie.GetComponent<Animator>().enabled = true;
            PorteGarderie.GetComponent<AudioSource>().enabled = true;

            // Arr�te la musique de la garderie
            Musique_Garderie.Stop();

            // Active la source audio attach�e � ce GameObject
            GetComponent<AudioSource>().enabled = true;

            // D�sactive le message et r�active la cam�ra principale apr�s 3 secondes
            Invoke("Desactiver_Message_Camera", 3f);
        }
    }

    // M�thode pour d�sactiver le message et r�activer la cam�ra principale
    void Desactiver_Message_Camera()
    {
        // Active la cam�ra principale (cam�ra 0)
        GestionnaireCamera.ActiveCam(0);

        // D�sactive le message pour courir
        Courir_Message.SetActive(false);
    }
}
