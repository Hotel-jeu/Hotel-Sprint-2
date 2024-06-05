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
    public InventoryManager inventoryManager;

    void Update()
    {
        boite = GetComponent<BoxCollider>();
        sceneActuelle = SceneManager.GetActiveScene();
        nomScene = sceneActuelle.name;

        inventoryManager = GameObject.Find("[InventoryManager]").GetComponent<InventoryManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player") && nomScene == "Tuto"){
            StartCoroutine(ChargerSceneDelai("Etage2", 0f));
        }
        else if (other.gameObject.CompareTag("player") && nomScene == "Etage2")
        {
            GetComponent<AudioSource>().enabled = true;
            StartCoroutine(ChargerSceneDelai("Etage1", 2f));
            ascenseur.GetComponent<Animator>().SetBool("fermerAscenseur", true);
        } else if (other.gameObject.CompareTag("player") && nomScene == "biblio") {
            mouvement.De_Biblio = true;
            StartCoroutine(ChargerSceneDelai("Etage1", 0f));
        } else if (other.gameObject.CompareTag("player") && nomScene == "Garderie") {
            mouvement.De_Garderie = true;
            StartCoroutine(ChargerSceneDelai("Etage1", 0f));
        } else if (other.gameObject.CompareTag("player") && nomScene == "Etage1") {
            GetComponent<AudioSource>().enabled = true;
            StartCoroutine(ChargerSceneDelai("Etage0", 2f));
            ascenseur.GetComponent<Animator>().SetBool("fermerAscenseur", true);
        }  else if (other.gameObject.CompareTag("player") && nomScene == "Etage0") {
            StartCoroutine(ChargerSceneDelai("Victoire", 0.5f));
        }
    }

    IEnumerator ChargerSceneDelai(string nomScene, float delai) {
        inventoryManager.SauvegardeInventaire();
        yield return new WaitForSeconds(delai);
        SceneManager.LoadScene(nomScene);
    }
}
