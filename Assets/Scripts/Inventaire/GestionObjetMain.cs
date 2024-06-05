using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionObjetMain : MonoBehaviour
{
    // Reference au script de gestionnaire d'inventaire
    public InventoryManager inventoryManager;
    // Les objets que le joueur a en main
    public GameObject Lampe;
    public GameObject Canette;
    public GameObject Bouteille;
    // Reference au l'item de chaque objet
    public Item LampeItem;
    public Item CanetteItem;
    public Item BouteilleItem;
    // Variable de delai pour éviter d'utiliser tous les objets d'un coup
    private bool Delai = false;


    // Update is called once per frame
    void Update()
    {   
        // Récupère l'objet présent dans le Slot de main principal
        Item ObjetEnMain = inventoryManager.GetSelectedItem(false);
        // Lance l'activation d'objet en utilisant l'objet récupéré
        ActivationObjetEnMain(ObjetEnMain);

        UtilisationObjetEnMain();
    }
    
    void ActivationObjetEnMain(Item ObjetEnMain) {
        // Si l'objet est équivalent à l'un des item déclaré au début
        // Active l'objet en main correspondant, si aucun ne correspond, rien s'active
        Lampe.SetActive(ObjetEnMain == LampeItem);
        Canette.SetActive(ObjetEnMain == CanetteItem);
        Bouteille.SetActive(ObjetEnMain == BouteilleItem);
    }

    // Utiliser l'objet en main
    void UtilisationObjetEnMain() {
        // Si le joueur appuie sur le bouton de sa souris, et que aucun UI n'est actif
        if(Input.GetMouseButtonDown(0) && !GestionJeuUI.UIActif) {
            // Récupère l'objet en main
            Item EnMain = inventoryManager.GetSelectedItem(false);
            // Si l'objet en main n'est pas la lampe, et que le délai n'est pas actif
            if(EnMain != LampeItem && !Delai) {
                // Et que l'objet est soit la canette ou la bouteille
                if (EnMain == CanetteItem || EnMain == BouteilleItem) {
                    // Active le délai, puis l'enlève après 2 secondes
                    Delai = true;
                    Invoke("DelaiFini", 2f);
                    // Ajoute 25% de sanité
                    GestionSanity.sanityActuel += 25f;
                    // Et utilise l'objet de l'inventaire (Avec le true), quand c'est true, ça enlève un count
                    inventoryManager.GetSelectedItem(true);
                }  
            }
        }
    }

    // Reset le délai
    void DelaiFini() {
        Delai = false;
    }
}