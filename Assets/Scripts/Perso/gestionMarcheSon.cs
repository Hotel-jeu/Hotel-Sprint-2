using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionMarcheSon : MonoBehaviour
{
    // Référence à l'AudioSource
    private AudioSource AudioSource;

    // Clips audio pour les différents types de marche
    public AudioClip sonMarche;
    public AudioClip sonAccroupi;
    public AudioClip sonCourse;

    private void Start()
    {
        // Obtenir le composant AudioSource attaché à l'objet
        AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Vérifier si une des touches de déplacement est enfoncée
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            // Si la touche Shift est enfoncée, jouer le son de course
            if (Input.GetKey(KeyCode.LeftShift))
            {
                JouerClip(sonCourse);
            }
            // Si la touche Ctrl est enfoncée, jouer le son accroupi
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                JouerClip(sonAccroupi);
            }
            // Sinon, jouer le son de marche
            else
            {
                JouerClip(sonMarche);
            }
        }
        else
        {
            // Si aucune touche n'est enfoncée, arrêter le son
            AudioSource.clip = null;
        }
    }

    // Méthode pour jouer un clip audio
    private void JouerClip(AudioClip clip)
    {
        // Si le clip est différent de celui actuellement joué
        if (clip != AudioSource.clip)
        {
            AudioSource.Stop();
            AudioSource.clip = clip;
            AudioSource.Play();
        }
    }
}
