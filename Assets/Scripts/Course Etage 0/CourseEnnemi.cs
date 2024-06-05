using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CourseEnnemi : MonoBehaviour
{
    // La position du joueur
    public Transform joueur;

    // Update is called once per frame
    void Update()
    {
        // Vitesse de l'ennemi
        GetComponent<NavMeshAgent>().speed = 5.6f;
        // Met comme destination de l'ennemi, la position du joueur
        GetComponent<NavMeshAgent>().SetDestination(joueur.position);
    }
}
