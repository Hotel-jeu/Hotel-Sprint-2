using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gestionScene : MonoBehaviour
{
    private BoxCollider boite;
    private Scene sceneActuelle;
    private string nomScene;


    public GameObject ascenseur;

    void Update()
    {
        boite = GetComponent<BoxCollider>();
        sceneActuelle = SceneManager.GetActiveScene();
        nomScene = sceneActuelle.name;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player") && nomScene == "Tuto"){
            StartCoroutine(ChargerSceneDelai("Etage2", 0f));
        }
        else if (other.gameObject.CompareTag("player") && nomScene == "Etage2")
        {
            StartCoroutine(ChargerSceneDelai("Etage0", 2f));
            ascenseur.GetComponent<Animator>().SetBool("fermerAscenseur", true);
        } else if (other.gameObject.CompareTag("player") && nomScene == "Etage0") {
            StartCoroutine(ChargerSceneDelai("Victoire", 0.5f));
        }
    }

    IEnumerator ChargerSceneDelai(string nomScene, float delai) {
        yield return new WaitForSeconds(delai);
        SceneManager.LoadScene(nomScene);
    }
}
