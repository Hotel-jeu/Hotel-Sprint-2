using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestion_Garderie : MonoBehaviour
{
    // Variables statiques pour suivre le nombre de différences trouvées et l'état de l'énigme
    static public int differences_trouver = 0;
    static public bool enigme_fini = false;

    // Variable pour suivre le nombre d'erreurs commises
    public int erreurs_commises = 0;

    // Référence au script Ennemi_Garderie_Malus
    public Ennemi_Garderie_Malus Ennemi_Garderie_Malus;

    // Référence à l'ennemi de chasse
    public GameObject Ennemi_Chasse;

    // Références à l'ennemi et au joueur
    public GameObject Ennemi;
    public GameObject Joueur;

    void Update()
    {
        // Vérifie si toutes les différences ont été trouvées et si l'énigme n'est pas encore terminée
        if (differences_trouver == 7 && !enigme_fini)
        {
            // Marque l'énigme comme terminée
            enigme_fini = true;

            // Désactive le comportement de l'ennemi malus
            Ennemi_Garderie_Malus.enabled = false;

            // Active la chasse après un délai de 5 secondes
            Invoke("ActiverChasse", 5f);
        }

        // Vérifie si le nombre d'erreurs commises est égal à 3
        if (erreurs_commises == 3)
        {
            // Désactive le comportement de l'ennemi malus
            Ennemi_Garderie_Malus.enabled = false;

            // Désactive le collider de l'ennemi, repositionne l'ennemi sur le joueur et réactive le collider
            Ennemi.GetComponent<Collider>().enabled = false;
            Ennemi.transform.position = Joueur.transform.position;
            Ennemi.GetComponent<Collider>().enabled = true;

            // Réinitialise le compteur d'erreurs
            erreurs_commises = 0;
        }
    }

    // Méthode pour activer la chasse
    void ActiverChasse()
    {
        // Active l'ennemi de chasse et désactive l'ennemi original
        Ennemi_Chasse.SetActive(true);
        Ennemi.SetActive(false);
    }
}
