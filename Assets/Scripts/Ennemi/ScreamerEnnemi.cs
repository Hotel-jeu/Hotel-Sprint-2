using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerEnnemi : MonoBehaviour
{
    // R�f�rence au mod�le de l'ennemi
    public GameObject EnnemiModele;

    // R�f�rence � l'audio clip du screamer
    public AudioClip Screamer;

    // M�thode pour d�clencher le jumpscare de l'ennemi
    public void JumpscareEnnemi()
    {
        // Debug pour v�rifier si la m�thode est appel�e
        Debug.Log("ici ?");

        // D�sactive et r�active l'audio source pour jouer le screamer
        GetComponent<AudioSource>().enabled = false;
        GetComponent<AudioSource>().clip = Screamer;
        GetComponent<AudioSource>().enabled = true;

        // D�clenche l'animation d'attraper sur le mod�le de l'ennemi
        EnnemiModele.GetComponent<Animator>().SetBool("Attraper", true);

        // Si l'ennemi a un NavMeshAgent, arr�te son mouvement
        if (GetComponent<UnityEngine.AI.NavMeshAgent>() != null)
        {
            GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0f;
        }
    }
}
