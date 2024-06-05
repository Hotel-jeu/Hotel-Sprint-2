using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObstacle : MonoBehaviour
{
    // Parent des obstacle à activer
    public GameObject obstacleSet;
    // Son à lancer quand l'obstacle est activé
    public AudioClip sonObstacle;
    public float delaiSon = 0f;

    void Start()
    {
        // Appelle la fonction qui désactive les animations pour que le début soit toujours désactivé
        DesactiverAnimation();
    }
    
    // Quand le joueur entre dans la zone du trigger, ça appelle la fonction qui active les animations
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "player") 
        {
            ActiverAnimation();
        }
    }

    // Fonction qui désactive les animations
    void DesactiverAnimation() {
        // Pour chaque enfant du parent qui a les obstacles
        foreach (Transform obstacle in obstacleSet.transform)
        {

            Animator animator = obstacle.GetComponent<Animator>();
            // Si l'obstacle à le tag ennemi, le désactive
            if (obstacle.CompareTag("ennemi") ) {
                obstacle.gameObject.SetActive(false);
            } // Sinon si l'animator existe, le désactive
            else if (animator != null)
            {
                animator.enabled = false;
            }
            
        }
    }
    // Fonction qui active les animations
    void ActiverAnimation() {
        // Pour chaque enfant du parent qui a les obstacles
        foreach (Transform obstacle in obstacleSet.transform)
        {
            Animator animator = obstacle.GetComponent<Animator>();
            // Si l'obstacle à le tag ennemi, et qu'il n'est pas déjà actif, l'active et lance le son de l'obstacle
            if (obstacle.CompareTag("ennemi") && !obstacle.gameObject.activeInHierarchy) {
                obstacle.gameObject.SetActive(true);
                if (sonObstacle != null) {
                    StartCoroutine(JouerUnSonApresDelai(sonObstacle, delaiSon));
                }
                
            } // Sinon, si l'obstacle a un animator qui existe, qu'il n'est pas déjà actif, et que ce n'est pas l'ennemi, l'active et lance le son de l'obstacle
            else if (animator != null && !animator.enabled && !obstacle.CompareTag("ennemi"))
            {
                animator.enabled = true;
                if (sonObstacle != null) {
                    StartCoroutine(JouerUnSonApresDelai(sonObstacle, delaiSon));
                }
                
            }
        }
    }

    // Lance le son apres un delai
    IEnumerator JouerUnSonApresDelai(AudioClip son, float delai) {
        yield return new WaitForSeconds(delai);
        GetComponent<AudioSource>().PlayOneShot(son);
    }
}