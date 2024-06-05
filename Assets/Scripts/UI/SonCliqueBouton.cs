using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonCliqueBouton : MonoBehaviour
{
    // Clip audio � jouer lors du clic sur un bouton
    public AudioClip Son_Clique;

    // Fonction publique qui peut �tre appel�e par l'�v�nement OnClick des boutons pour jouer un son
    public void SonClique()
    {
        // Trouver l'objet "[Son UI]" dans la sc�ne et obtenir son composant AudioSource
        AudioSource audioSource = GameObject.Find("[Son UI]").GetComponent<AudioSource>();
        // Jouer le clip audio d�fini dans Son_Clique
        audioSource.PlayOneShot(Son_Clique);
    }
}
