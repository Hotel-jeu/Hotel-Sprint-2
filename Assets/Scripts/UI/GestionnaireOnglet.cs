using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestionnaireOnglet : MonoBehaviour
{
    // Start is called before the first frame update

    // Tableau des onglets
    public GameObject[] lesOnglets;


    void Start()
    {

        // Active l'onglet 0 (Le curseur) au début
        activerOnglet(0);
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    // Active l'onglet en prenant son index, en désactivant tt le reste
    public void activerOnglet(int indexOngletActif) {

        // Si l'index appelé est négatif, ou plus grand que la taille du tableau, arrête la fonction
        if (indexOngletActif < 0 || indexOngletActif >= lesOnglets.Length) {
            return;
        }

        // Sinon désactive tous les éléments du tableau des onglets (Les UI)
        foreach (GameObject onglet in lesOnglets) {
            if(onglet != null) {
                onglet.SetActive(false);
            }
        }
        // Puis active celui avec l'index qu'on a mis
        lesOnglets[indexOngletActif].SetActive(true);
    }


    // Fonction publique qui rend le curseur invisible
    public void CurseurInvisible() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
