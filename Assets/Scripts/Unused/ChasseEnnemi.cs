// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;

// public class ChasseEnnemi : MonoBehaviour
// {
//     public GameObject player;
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (VisionEnnemi.trouver == true) {
//             GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
//             GetComponent<NavMeshAgent>().speed = 3.5f;
//             GetComponent<Animator>().SetBool("Attack", true);
//         } else {
//             GetComponent<NavMeshAgent>().speed = 1.5f;
//             GetComponent<Animator>().SetBool("Attack", false);
//     }
//     }
// }
