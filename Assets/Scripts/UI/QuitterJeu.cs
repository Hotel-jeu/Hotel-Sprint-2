using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitterJeu : MonoBehaviour
{
    // Fonction publique qui peut �tre appel�e par l'�v�nement OnClick des boutons pour quitter le jeu
    public void QuitterLeJeu()
    {
        // Quitter l'application
        Application.Quit();

        // Si on est dans l'�diteur Unity, arr�ter le mode Play
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
