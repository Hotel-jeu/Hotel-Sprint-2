using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CliqueBouton : MonoBehaviour
{
    // Nom de la scène à charger
    public string SceneACharger;

    // Fonction publique qui peut être appelée par le OnClick des boutons des canvas
    public void chargerScene()
    {
        // Charger la scène spécifiée par SceneACharger
        SceneManager.LoadScene(SceneACharger);
    }
}
