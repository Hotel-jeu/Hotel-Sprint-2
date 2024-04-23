using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CliqueBouton : MonoBehaviour
{
    // Start is called before the first frame update

    public string SceneACharger;
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chargerScene() {
        SceneManager.LoadScene(SceneACharger);
    }
}