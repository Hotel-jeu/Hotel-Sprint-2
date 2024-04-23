using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObstacle : MonoBehaviour
{
    public GameObject obstacleSet;

    void Start()
    {
        DesactiverAnimation();
    }

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.CompareTag("player")) 
        {
            ActiverAnimation();
        }
    }

    void DesactiverAnimation()
    {

        foreach (Transform obstacle in obstacleSet.transform)
        {
            Animator animator = obstacle.GetComponent<Animator>();
            if (animator != null)
            {
                animator.enabled = false;
            }
            if (obstacle.CompareTag("ennemi") ) {
                obstacle.gameObject.SetActive(false);
            }
        }
    }

    void ActiverAnimation()
    {

        foreach (Transform obstacle in obstacleSet.transform)
        {
            Animator animator = obstacle.GetComponent<Animator>();
            if (animator != null)
            {
                animator.enabled = true;
            }
            if (obstacle.CompareTag("ennemi")) {
                obstacle.gameObject.SetActive(true);
            }
        }
    }
}
