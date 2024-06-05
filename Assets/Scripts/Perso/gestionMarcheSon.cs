using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionMarcheSon : MonoBehaviour
{
    // R�f�rence � l'AudioSource
    private AudioSource AudioSource;

    // Clips audio pour les diff�rents types de marche
    public AudioClip sonMarche;
    public AudioClip sonAccroupi;
    public AudioClip sonCourse;

    private void Start()
    {
        // Obtenir le composant AudioSource attach� � l'objet
        AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // V�rifier si une des touches de d�placement est enfonc�e
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            // Si la touche Shift est enfonc�e, jouer le son de course
            if (Input.GetKey(KeyCode.LeftShift))
            {
                JouerClip(sonCourse);
            }
            // Si la touche Ctrl est enfonc�e, jouer le son accroupi
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
            // Si aucune touche n'est enfonc�e, arr�ter le son
            AudioSource.clip = null;
        }
    }

    // M�thode pour jouer un clip audio
    private void JouerClip(AudioClip clip)
    {
        // Si le clip est diff�rent de celui actuellement jou�
        if (clip != AudioSource.clip)
        {
            AudioSource.Stop();
            AudioSource.clip = clip;
            AudioSource.Play();
        }
    }
}
