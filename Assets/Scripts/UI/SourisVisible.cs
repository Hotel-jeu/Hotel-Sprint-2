using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourisVisible : MonoBehaviour
{
    // Rend la souris visible quand ça commence (Utilisé dans le menu)

    void Start()
    {
        // Débloque le curseur de la souris
        Cursor.lockState = CursorLockMode.None;
        // Rend le curseur de la souris visible
        Cursor.visible = true;
    }
}
