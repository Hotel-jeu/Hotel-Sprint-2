using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationEnnemi : MonoBehaviour
{
    // R�f�rence au mod�le de l'ennemi
    public GameObject EnnemiModele;

    void Update()
    {
        // Met � jour le param�tre "Vitesse" de l'Animator du mod�le de l'ennemi
        // en fonction de la vitesse actuelle du NavMeshAgent
        EnnemiModele.GetComponent<Animator>().SetFloat("Vitesse", GetComponent<NavMeshAgent>().speed);
    }
}
