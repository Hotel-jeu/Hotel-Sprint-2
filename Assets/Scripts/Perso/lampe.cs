using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lampe : MonoBehaviour
{
    // R�f�rence � l'objet de la lampe torche
    public GameObject lampeTorche;

    // R�f�rence � l'AudioSource pour le son de la lampe
    public AudioSource audioSource;
    // Clip audio pour le son de la lampe
    public AudioClip sonLampe;

    // R�f�rence � la lumi�re de la lampe
    public Light lumiereLampe;

    private void Update()
    {
        // Si le bouton gauche de la souris est enfonc� et aucun UI n'est actif
        if (Input.GetMouseButtonDown(0) && !GestionJeuUI.UIActif)
        {
            // Afficher un message dans la console pour d�bogage
            Debug.Log("ff");

            // Arr�ter tout son actuel de la lampe
            audioSource.Stop();
            // Activer ou d�sactiver la lampe torche
            lampeTorche.SetActive(!lampeTorche.activeSelf);
            // Jouer le son de la lampe
            audioSource.PlayOneShot(sonLampe);
        }
    }
}
