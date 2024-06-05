using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation_Enigme : MonoBehaviour
{
    // R�f�rence au GameObject Ennemi
    public GameObject Ennemi;

    // R�f�rence au GameObject Porte
    public GameObject Porte;

    // R�f�rence � l'AudioClip pour le son de la porte qui se ferme
    public AudioClip SonPorteFermer;

    // M�thode appel�e lorsqu'un autre Collider entre dans le trigger
    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si l'objet qui est entr� dans le trigger a le tag "player"
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

            // D�sactive ce GameObject
            gameObject.SetActive(false);

            // D�truit ce GameObject
            Destroy(gameObject);
        }
    }
}
