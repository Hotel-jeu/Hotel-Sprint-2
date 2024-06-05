using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetVariableStatique : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
        // Reset la sanité
        GestionSanity.sanityActuel = 100f;
        // Reset l'inventaire
        InventoryManager.savedItemsData.Clear();
        // Reset l'énigme étage 2
        gestionEnigme2.codesTrouver = 0f;
        activationCode.codesObtenus.Clear();
        // Reset l'énigme étage 1
        Debut_Enigme1.deja_lancer = false;
        SuiviEnigmes.Son_Barriere_Garderie_Fait = false;
        SuiviEnigmes.Son_Barriere_Biblio_Fait = false;
        mouvement.De_Garderie = false;
        mouvement.De_Biblio = false;
        // Reset la biblio
        gestionEnigmeBiblio.Nbr_Photos_Trouver = 0;
        gestionEnigmeBiblio.Enigme_Biblio_Fini = false;
        activationPhoto.Photos_Obtenus.Clear();
        // Reset la garderie
        Gestion_Garderie.differences_trouver = 0;
        Gestion_Garderie.enigme_fini = false;
        Gestion_Differences.erreurs_corriger.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
