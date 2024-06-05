using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionAnimPerso : MonoBehaviour
{
    // Référence à l'Animator
    private Animator animator;

    private void Start()
    {
        // Obtenir le composant Animator attaché à l'objet
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Vérifier si l'Animator est disponible
        if (animator != null)
        {
            // Si la touche Ctrl est enfoncée seule ou avec les touches de déplacement
            if (Input.GetKey(KeyCode.LeftControl) ||
                (Input.GetKey(KeyCode.LeftControl) &&
                (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))))
            {
                // Activer l'animation de crouch et désactiver celle de marche
                animator.SetBool("marche", false);
                animator.SetBool("crouch", true);
            }
            // Si une des touches de déplacement est enfoncée
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
            {
                // Activer l'animation de marche et désactiver celle de crouch
                animator.SetBool("marche", true);
                animator.SetBool("crouch", false);
            }
            // Sinon, désactiver toutes les animations
            else
            {
                animator.SetBool("marche", false);
                animator.SetBool("crouch", false);
            }
        }
    }
}
