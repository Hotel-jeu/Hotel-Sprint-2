using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestionSanity : MonoBehaviour
{
    // Valeur maximale de la santé mentale
    private float sanityMaximum = 100f;
    // Vitesse de perte de la santé mentale
    private float vitesseDePerte = 1f;
    // Slider UI pour afficher la santé mentale
    public Slider sliderSanity;

    // Valeur actuelle de la santé mentale (statique)
    static public float sanityActuel = 100f;

    // Référence au gestionnaire d'inventaire
    public InventoryManager inventoryManager;

    // Objet pour indiquer un danger de santé mentale
    public GameObject SaniteDanger;

    // Méthode Start appelée au démarrage du script
    void Start()
    {
        // Trouver le gestionnaire d'inventaire dans la scène
        inventoryManager = GameObject.Find("[InventoryManager]").GetComponent<InventoryManager>();
        // Démarrer la coroutine pour diminuer la santé mentale
        StartCoroutine(DiminuerSanity());
    }

    // Méthode Update appelée à chaque frame
    void Update()
    {
        // Mettre à jour la valeur du slider si le slider est assigné
        if (sliderSanity != null)
        {
            sliderSanity.value = sanityActuel;
        }

        // Empêcher la santé mentale de dépasser le maximum
        if (sanityActuel > sanityMaximum)
        {
            sanityActuel = 100f;
        }

        // Gérer le cas où la santé mentale atteint zéro
        if (sanityActuel <= 0f)
        {
            // Supprimer l'inventaire et réinitialiser la santé mentale
            inventoryManager.SupprimerInventaire();
            sanityActuel = 100f;
            // Charger la scène "Perdu"
            SceneManager.LoadScene("Perdu");
        }

        // Afficher ou cacher l'objet de danger en fonction de la santé mentale
        if (sanityActuel <= 20f)
        {
            SaniteDanger.SetActive(true);
        }
        else
        {
            SaniteDanger.SetActive(false);
        }
    }

    // Coroutine pour diminuer la santé mentale
    IEnumerator DiminuerSanity()
    {
        // Tant que la santé mentale est positive
        while (sanityActuel > 0f)
        {
            // Attendre 4 secondes entre chaque diminution
            yield return new WaitForSeconds(4f);
            // Diminuer la santé mentale
            sanityActuel -= vitesseDePerte;
        }
    }
}
