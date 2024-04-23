using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LancerProchaineScene : MonoBehaviour
{

    public string Scene;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChargerSceneDelai(Scene, 5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChargerSceneDelai(string nomScene, float delai) {
        yield return new WaitForSeconds(delai);
        SceneManager.LoadScene(nomScene);
    }
}
