using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionEtageRendu : MonoBehaviour
{
    // Variable pour stocker la sc�ne actuelle
    private Scene sceneActuelle;

    // Variable statique pour stocker le nom de l'�tage rendu
    public static string EtageRendu;

    void Start()
    {
        // Obtenir la sc�ne active actuelle
        sceneActuelle = SceneManager.GetActiveScene();
    }
    void Update()
    {
        // Mettre � jour le nom de l'�tage rendu avec le nom de la sc�ne actuelle
        EtageRendu = sceneActuelle.name;
    }
}
