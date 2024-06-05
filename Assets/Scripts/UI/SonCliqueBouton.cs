using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonCliqueBouton : MonoBehaviour
{
    // Clip audio à jouer lors du clic sur un bouton
    public AudioClip Son_Clique;

    // Fonction publique qui peut être appelée par l'événement OnClick des boutons pour jouer un son
    public void SonClique()
    {
        // Trouver l'objet "[Son UI]" dans la scène et obtenir son composant AudioSource
        AudioSource audioSource = GameObject.Find("[Son UI]").GetComponent<AudioSource>();
        // Jouer le clip audio défini dans Son_Clique
        audioSource.PlayOneShot(Son_Clique);
    }
}
