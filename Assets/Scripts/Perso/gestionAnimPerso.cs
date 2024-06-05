using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionAnimPerso : MonoBehaviour
{
    // R�f�rence � l'Animator
    private Animator animator;

    private void Start()
    {
        // Obtenir le composant Animator attach� � l'objet
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // V�rifier si l'Animator est disponible
        if (animator != null)
        {
            // Si la touche Ctrl est enfonc�e seule ou avec les touches de d�placement
            if (Input.GetKey(KeyCode.LeftControl) ||
                (Input.GetKey(KeyCode.LeftControl) &&
                (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))))
            {
                // Activer l'animation de crouch et d�sactiver celle de marche
                animator.SetBool("marche", false);
                animator.SetBool("crouch", true);
            }
            // Si une des touches de d�placement est enfonc�e
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
            {
                // Activer l'animation de marche et d�sactiver celle de crouch
                animator.SetBool("marche", true);
                animator.SetBool("crouch", false);
            }
            // Sinon, d�sactiver toutes les animations
            else
            {
                animator.SetBool("marche", false);
                animator.SetBool("crouch", false);
            }
        }
    }
}
