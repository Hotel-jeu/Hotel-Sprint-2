using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestionSanity : MonoBehaviour
{
    // Valeur maximale de la sant� mentale
    private float sanityMaximum = 100f;
    // Vitesse de perte de la sant� mentale
    private float vitesseDePerte = 1f;
    // Slider UI pour afficher la sant� mentale
    public Slider sliderSanity;

    // Valeur actuelle de la sant� mentale (statique)
    static public float sanityActuel = 100f;

    // R�f�rence au gestionnaire d'inventaire
    public InventoryManager inventoryManager;

    // Objet pour indiquer un danger de sant� mentale
    public GameObject SaniteDanger;

    // M�thode Start appel�e au d�marrage du script
    void Start()
    {
        // Trouver le gestionnaire d'inventaire dans la sc�ne
        inventoryManager = GameObject.Find("[InventoryManager]").GetComponent<InventoryManager>();
        // D�marrer la coroutine pour diminuer la sant� mentale
        StartCoroutine(DiminuerSanity());
    }

    // M�thode Update appel�e � chaque frame
    void Update()
    {
        // Mettre � jour la valeur du slider si le slider est assign�
        if (sliderSanity != null)
        {
            sliderSanity.value = sanityActuel;
        }

        // Emp�cher la sant� mentale de d�passer le maximum
        if (sanityActuel > sanityMaximum)
        {
            sanityActuel = 100f;
        }

        // G�rer le cas o� la sant� mentale atteint z�ro
        if (sanityActuel <= 0f)
        {
            // Supprimer l'inventaire et r�initialiser la sant� mentale
            inventoryManager.SupprimerInventaire();
            sanityActuel = 100f;
            // Charger la sc�ne "Perdu"
            SceneManager.LoadScene("Perdu");
        }

        // Afficher ou cacher l'objet de danger en fonction de la sant� mentale
        if (sanityActuel <= 20f)
        {
            SaniteDanger.SetActive(true);
        }
        else
        {
            SaniteDanger.SetActive(false);
        }
    }

    // Coroutine pour diminuer la sant� mentale
    IEnumerator DiminuerSanity()
    {
        // Tant que la sant� mentale est positive
        while (sanityActuel > 0f)
        {
            // Attendre 4 secondes entre chaque diminution
            yield return new WaitForSeconds(4f);
            // Diminuer la sant� mentale
            sanityActuel -= vitesseDePerte;
        }
    }
}
