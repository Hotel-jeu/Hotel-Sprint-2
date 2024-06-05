using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestion_Differences : MonoBehaviour
{
    // R�f�rence au GameObject qui repr�sente l'erreur � corriger
    public GameObject erreur_a_corriger;

    // Identifiant unique pour cette erreur
    public int uniqueId;

    // Ensemble statique pour stocker les identifiants des erreurs corrig�es
    public static HashSet<int> erreurs_corriger = new HashSet<int>();

    // M�thode appel�e au d�marrage du script
    void Start()
    {
        // V�rifie si cette erreur a d�j� �t� corrig�e
        if (erreurs_corriger.Contains(uniqueId))
        {
            // Si corrig�e, d�sactive le tag et active l'objet erreur_a_corriger
            gameObject.tag = "Untagged";
            erreur_a_corriger.SetActive(true);
        }
        else
        {
            // Si non corrig�e, d�sactive l'objet erreur_a_corriger
            erreur_a_corriger.SetActive(false);
        }
    }

    // M�thode pour corriger l'erreur
    public void CorrigerErreur()
    {
        // D�sactive le tag et active l'objet erreur_a_corriger
        gameObject.tag = "Untagged";
        erreur_a_corriger.SetActive(true);
        // Ajoute l'identifiant unique � l'ensemble des erreurs corrig�es
        erreurs_corriger.Add(uniqueId);
    }
}
