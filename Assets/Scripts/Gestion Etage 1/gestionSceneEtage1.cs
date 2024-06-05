using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gestionSceneEtage1 : MonoBehaviour
{
    // Nom de la sc�ne � charger
    public string SceneACharger;

    // R�f�rence � l'InventoryManager
    public InventoryManager inventoryManager;

    void Start()
    {
        // Trouver et assigner l'InventoryManager
        inventoryManager = GameObject.Find("[InventoryManager]").GetComponent<InventoryManager>();
    }

    // M�thode appel�e quand un autre objet entre dans le trigger
    private void OnTriggerEnter(Collider collider)
    {
        // Si l'objet est le joueur
        if (collider.gameObject.CompareTag("player"))
        {
            // Sauvegarder l'inventaire et charger la nouvelle sc�ne
            inventoryManager.SauvegardeInventaire();
            SceneManager.LoadScene(SceneACharger);
        }
    }
}
