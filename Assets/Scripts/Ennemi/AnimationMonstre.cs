using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationMonstre : MonoBehaviour
{
    // Référence au modèle de l'ennemi
    public GameObject EnnemiModele;

    void Update()
    {
        // Met à jour le paramètre "Vitesse" de l'Animator du modèle de l'ennemi
        // en fonction de la vitesse actuelle du NavMeshAgent attaché à ce GameObject
        EnnemiModele.GetComponent<Animator>().SetFloat("Vitesse", GetComponent<NavMeshAgent>().speed);
    }
}
