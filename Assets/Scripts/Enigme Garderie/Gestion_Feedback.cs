using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestion_Feedback : MonoBehaviour
{
    // R�f�rence � l'audio clip pour l'alarme d'�chec
    public AudioClip Alarme_Echec;
    // R�f�rence � l'audio clip pour l'alarme de r�ussite
    public AudioClip Alarme_Reussite;

    // Coroutine pour faire clignoter une lumi�re avec une couleur sp�cifique
    public IEnumerator ClignotementLumiere(Color couleur_lumiere)
    {
        // Joue le son appropri� en fonction de la couleur de la lumi�re
        if (couleur_lumiere == Color.red)
        {
            GetComponent<AudioSource>().PlayOneShot(Alarme_Echec);
        }
        else if (couleur_lumiere == Color.green)
        {
            GetComponent<AudioSource>().PlayOneShot(Alarme_Reussite);
        }

        // Change la couleur de la lumi�re et fait clignoter
        GetComponent<Light>().color = couleur_lumiere;
        yield return new WaitForSeconds(0.3f);
        GetComponent<Light>().color = Color.white;
        yield return new WaitForSeconds(0.3f);
        GetComponent<Light>().color = couleur_lumiere;
        yield return new WaitForSeconds(0.3f);
        GetComponent<Light>().color = Color.white;
        yield return new WaitForSeconds(0.3f);
        GetComponent<Light>().color = couleur_lumiere;
        yield return new WaitForSeconds(0.3f);
        GetComponent<Light>().color = Color.white;
    }
}
