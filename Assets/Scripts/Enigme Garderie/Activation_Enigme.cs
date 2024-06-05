using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation_Enigme : MonoBehaviour
{
    // Référence au GameObject Ennemi
    public GameObject Ennemi;

    // Référence au GameObject Porte
    public GameObject Porte;

    // Référence à l'AudioClip pour le son de la porte qui se ferme
    public AudioClip SonPorteFermer;

    // Méthode appelée lorsqu'un autre Collider entre dans le trigger
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet qui est entré dans le trigger a le tag "player"
        if (other.gameObject.CompareTag("player"))
        {
            // Active l'animation de fermeture de la porte
            Porte.GetComponent<Animator>().SetBool("porteFermer", true);

            // Joue le son de la porte qui se ferme
            GetComponent<AudioSource>().PlayOneShot(SonPorteFermer);

            // Change le tag de la porte pour "Untagged"
            Porte.tag = "Untagged";

            // Active l'ennemi
            Ennemi.SetActive(true);

            // Désactive ce GameObject
            gameObject.SetActive(false);

            // Détruit ce GameObject
            Destroy(gameObject);
        }
    }
}
