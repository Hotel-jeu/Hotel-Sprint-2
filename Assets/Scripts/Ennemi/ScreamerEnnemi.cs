using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerEnnemi : MonoBehaviour
{
    // Référence au modèle de l'ennemi
    public GameObject EnnemiModele;

    // Référence à l'audio clip du screamer
    public AudioClip Screamer;

    // Méthode pour déclencher le jumpscare de l'ennemi
    public void JumpscareEnnemi()
    {
        // Debug pour vérifier si la méthode est appelée
        Debug.Log("ici ?");

        // Désactive et réactive l'audio source pour jouer le screamer
        GetComponent<AudioSource>().enabled = false;
        GetComponent<AudioSource>().clip = Screamer;
        GetComponent<AudioSource>().enabled = true;

        // Déclenche l'animation d'attraper sur le modèle de l'ennemi
        EnnemiModele.GetComponent<Animator>().SetBool("Attraper", true);

        // Si l'ennemi a un NavMeshAgent, arrête son mouvement
        if (GetComponent<UnityEngine.AI.NavMeshAgent>() != null)
        {
            GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0f;
        }
    }
}
