using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class IndiceEnigme : MonoBehaviour
{

    public TextMeshProUGUI TexteIndice;

    private string sceneActuelle;

    // Start is called before the first frame update
    void Start()
    {
        sceneActuelle = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneActuelle == "Etage2") {
            TexteIndice.text = gestionEnigme2.codesTrouver + " / 6";
        } else if (sceneActuelle == "Garderie") {
            TexteIndice.text = Gestion_Garderie.differences_trouver + " / 7";
        } else if (sceneActuelle == "biblio") {
            TexteIndice.text = gestionEnigmeBiblio.Nbr_Photos_Trouver + " / 5";
        }
    }
}
