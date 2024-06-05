using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LancerProchaineScene : MonoBehaviour
{
    // String publique pour le nom de la scène à charger
    public string Scene;

    void Start()
    {
        // Vérifier si la scène actuelle est "Perdu"
        if (SceneManager.GetActiveScene().name == "Perdu")
        {
            // Charger l'étage rendu après 5 secondes
            StartCoroutine(ChargerSceneDelai(GestionEtageRendu.EtageRendu, 5f));
        }
        else
        {
            // Charger la scène spécifiée après 5 secondes
            StartCoroutine(ChargerSceneDelai(Scene, 5f));
        }
    }

    // Coroutine pour attendre un délai et charger une scène
    IEnumerator ChargerSceneDelai(string nomScene, float delai)
    {
        // Attendre le délai spécifié
        yield return new WaitForSeconds(delai);
        // Charger la scène spécifiée
        SceneManager.LoadScene(nomScene);
    }
}
