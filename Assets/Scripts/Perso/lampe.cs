using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lampe : MonoBehaviour
{
    // Référence à l'objet de la lampe torche
    public GameObject lampeTorche;

    // Référence à l'AudioSource pour le son de la lampe
    public AudioSource audioSource;
    // Clip audio pour le son de la lampe
    public AudioClip sonLampe;

    // Référence à la lumière de la lampe
    public Light lumiereLampe;

    private void Update()
    {
        // Si le bouton gauche de la souris est enfoncé et aucun UI n'est actif
        if (Input.GetMouseButtonDown(0) && !GestionJeuUI.UIActif)
        {
            // Afficher un message dans la console pour débogage
            Debug.Log("ff");

            // Arrêter tout son actuel de la lampe
            audioSource.Stop();
            // Activer ou désactiver la lampe torche
            lampeTorche.SetActive(!lampeTorche.activeSelf);
            // Jouer le son de la lampe
            audioSource.PlayOneShot(sonLampe);
        }
    }
}
