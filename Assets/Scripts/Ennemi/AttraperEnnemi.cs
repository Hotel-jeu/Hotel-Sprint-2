using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttraperEnnemi : MonoBehaviour
{
    // Indicateur de test, probablement utilisé pour le débogage
    public bool test = false;

    // Référence au gestionnaire de caméra
    public GestionnaireCamera gestionnaireCamera;

    // Référence au gestionnaire d'inventaire
    public InventoryManager inventoryManager;

    void Start()
    {
        // Initialisation de la référence au gestionnaire d'inventaire
        inventoryManager = GameObject.Find("[InventoryManager]").GetComponent<InventoryManager>();
    }

    // Méthode appelée lorsque le joueur entre en collision avec le collider de l'ennemi
    private void OnTriggerEnter(Collider collider)
    {
        // Vérifie si le collider appartient au joueur
        if (collider.gameObject.CompareTag("player"))
        {
            // Supprime l'inventaire du joueur
            inventoryManager.SupprimerInventaire();

            // Réinitialise la santé mentale du joueur
            GestionSanity.sanityActuel = 100f;

            // Change la caméra active en fonction du nom de l'ennemi
            if (gameObject.name == "Ennemi Chase")
            {
                gestionnaireCamera.ActiveCam(3);
            }
            else
            {
                gestionnaireCamera.ActiveCam(2);
            }

            // Lance le jumpscare de l'ennemi
            GetComponent<ScreamerEnnemi>().JumpscareEnnemi();

            // Si l'ennemi a une route définie, marque l'ennemi comme ayant attrapé le joueur
            if (GetComponent<RouteEnnemi>() != null)
            {
                GetComponent<RouteEnnemi>().attraper = true;
            }

            // Charge la scène de défaite après un délai de 2 secondes
            Invoke("InvoquerSceneDefaite", 2f);
        }
    }

    // Méthode pour charger la scène de défaite
    private void InvoquerSceneDefaite()
    {
        SceneManager.LoadScene("Perdu");
    }
}
