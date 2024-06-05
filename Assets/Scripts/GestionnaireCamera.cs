using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionnaireCamera : MonoBehaviour

{
    // Tableau des caméra
    public GameObject[] lesCams;


    // Start is called before the first frame update
    void Start()
    {
        // Active la caméra 0 (Caméra du joueur) au début
        ActiveCam(0);

    }
    // Active la caméra en prenant son index, en désactivant tt le reste
    public void ActiveCam(int indexCamActive)
    {   
        // Si l'index appelé est négatif, ou plus grand que la taille du tableau, arrête la fonction
        if (indexCamActive < 0 || indexCamActive >= lesCams.Length) {
            return;
        }

        // Sinon désactive tous les éléments du tableau des caméra (Les UI)
        foreach (GameObject cam in lesCams)
        {
            cam.SetActive(false);
        }
        // Puis active celle avec l'index qu'on a mis
        lesCams[indexCamActive].SetActive(true);
    }
}
