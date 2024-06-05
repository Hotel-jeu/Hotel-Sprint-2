using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi_Garderie_Malus : MonoBehaviour
{
    // R�f�rence � la source audio pour la musique de la garderie
    public AudioSource Musique_Garderie;

    // Variables pour les dur�es al�atoires de rotation et d'observation
    public float temps_minimum_tourner = 3.0f;
    public float temps_maximum_tourner = 10.0f;
    public float temps_minimum_observer = 2.0f;
    public float temps_maximum_observer = 4.0f;
    public float vitesseRotation = 1.0f;

    // Variables d'�tat pour l'observation et l'immunit�
    private bool EnObservation = false;
    private bool EnImmunite = false;

    // Positions de rotation pour tourner et observer
    private Quaternion Position_Tourner;
    private Quaternion Position_Observer;

    // R�f�rences aux scripts de gestion et d'interaction
    public Gestion_Garderie Gestion_Garderie;
    public Gestion_Feedback Gestion_Feedback;
    public interactionPerso interactionPerso;

    // M�thode appel�e au d�marrage du script
    void Start()
    {
        // Initialisation des positions de rotation
        Position_Tourner = Quaternion.Euler(0, 70, 0);
        Position_Observer = Quaternion.Euler(0, 250, 0);

        // Demarrage du cycle de rotation
        StartCoroutine(Tourner_Cycle());
    }

    // M�thode appel�e � chaque frame
    void Update()
    {
        // Si l'ennemi observe et n'est pas en immunit�
        if (Observe() && !EnImmunite)
        {
            // Si une entr�e est d�tect�e sur les axes de d�placement
            if (Input.GetAxis("Vertical") > 0.1f || Input.GetAxis("Horizontal") > 0.1f)
            {
                // Active l'immunit� et g�re les cons�quences de l'erreur
                EnImmunite = true;
                Gestion_Garderie.erreurs_commises++;
                interactionPerso.Une_Vie_Fini();
                StartCoroutine(Gestion_Feedback.ClignotementLumiere(Color.red));
                Invoke("Fin_Immunite", 1f);
            }
        }
    }

    // Coroutine pour g�rer le cycle de rotation et d'observation
    IEnumerator Tourner_Cycle()
    {
        while (true)
        {
            // Phase de rotation
            EnObservation = false;
            float temps_tourner = Random.Range(temps_minimum_tourner, temps_maximum_tourner);
            StartCoroutine(TournerDoucement(Position_Tourner, temps_tourner));

            // Gestion de la musique
            if (!Musique_Garderie.isPlaying)
            {
                if (Musique_Garderie.time > 0)
                {
                    Musique_Garderie.UnPause();
                }
                else
                {
                    Musique_Garderie.Play();
                }
            }

            // Attente de la fin de la rotation
            yield return new WaitForSeconds(temps_tourner);

            // Phase d'observation
            EnImmunite = true;
            EnObservation = true;
            Invoke("Fin_Immunite", 0.5f);
            float temps_observer = Random.Range(temps_minimum_observer, temps_maximum_observer);
            StartCoroutine(TournerDoucement(Position_Observer, temps_observer));

            // Pause de la musique
            Musique_Garderie.Pause();
            yield return new WaitForSeconds(temps_observer);
        }
    }

    // Coroutine pour tourner doucement vers une rotation cible
    IEnumerator TournerDoucement(Quaternion RotationCible, float tempsTotal)
    {
        float tempsPasser = 0;
        while (tempsPasser < tempsTotal)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, RotationCible, tempsPasser / tempsTotal);
            tempsPasser += Time.deltaTime * vitesseRotation;
            yield return null;
        }
        transform.rotation = RotationCible;
    }

    // M�thode pour terminer l'immunit�
    void Fin_Immunite()
    {
        EnImmunite = false;
    }

    // M�thode pour v�rifier si l'ennemi est en observation
    public bool Observe()
    {
        return EnObservation;
    }
}
