using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionEtageRendu : MonoBehaviour
{
    // Variable pour stocker la scène actuelle
    private Scene sceneActuelle;

    // Variable statique pour stocker le nom de l'étage rendu
    public static string EtageRendu;

    void Start()
    {
        // Obtenir la scène active actuelle
        sceneActuelle = SceneManager.GetActiveScene();
    }
    void Update()
    {
        // Mettre à jour le nom de l'étage rendu avec le nom de la scène actuelle
        EtageRendu = sceneActuelle.name;
    }
}
