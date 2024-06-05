using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationMonstre : MonoBehaviour
{
    // R�f�rence au mod�le de l'ennemi
    public GameObject EnnemiModele;

    void Update()
    {
        // Met � jour le param�tre "Vitesse" de l'Animator du mod�le de l'ennemi
        // en fonction de la vitesse actuelle du NavMeshAgent attach� � ce GameObject
        EnnemiModele.GetComponent<Animator>().SetFloat("Vitesse", GetComponent<NavMeshAgent>().speed);
    }
}
