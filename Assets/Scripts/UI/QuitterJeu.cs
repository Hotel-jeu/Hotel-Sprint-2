using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitterJeu : MonoBehaviour
{
    // Fonction publique qui peut être appelée par l'événement OnClick des boutons pour quitter le jeu
    public void QuitterLeJeu()
    {
        // Quitter l'application
        Application.Quit();

        // Si on est dans l'éditeur Unity, arrêter le mode Play
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
