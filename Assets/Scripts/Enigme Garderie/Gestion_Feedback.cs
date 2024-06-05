using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestion_Feedback : MonoBehaviour
{
    // Référence à l'audio clip pour l'alarme d'échec
    public AudioClip Alarme_Echec;
    // Référence à l'audio clip pour l'alarme de réussite
    public AudioClip Alarme_Reussite;

    // Coroutine pour faire clignoter une lumière avec une couleur spécifique
    public IEnumerator ClignotementLumiere(Color couleur_lumiere)
    {
        // Joue le son approprié en fonction de la couleur de la lumière
        if (couleur_lumiere == Color.red)
        {
            GetComponent<AudioSource>().PlayOneShot(Alarme_Echec);
        }
        else if (couleur_lumiere == Color.green)
        {
            GetComponent<AudioSource>().PlayOneShot(Alarme_Reussite);
        }

        // Change la couleur de la lumière et fait clignoter
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
