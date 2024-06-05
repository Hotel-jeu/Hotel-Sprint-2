using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gestionSceneEtage1 : MonoBehaviour
{
    // Nom de la scène à charger
    public string SceneACharger;

    // Référence à l'InventoryManager
    public InventoryManager inventoryManager;

    void Start()
    {
        // Trouver et assigner l'InventoryManager
        inventoryManager = GameObject.Find("[InventoryManager]").GetComponent<InventoryManager>();
    }

    // Méthode appelée quand un autre objet entre dans le trigger
    private void OnTriggerEnter(Collider collider)
    {
        // Si l'objet est le joueur
        if (collider.gameObject.CompareTag("player"))
        {
            // Sauvegarder l'inventaire et charger la nouvelle scène
            inventoryManager.SauvegardeInventaire();
            SceneManager.LoadScene(SceneACharger);
        }
    }
}
