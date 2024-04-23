using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activationCode : MonoBehaviour
{

    public GameObject codeAffiche;
    // Start is called before the first frame update
    void Start()
    {
        codeAffiche.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiverCode() {
        codeAffiche.SetActive(true);
        gestionEnigme2.codesTrouver++;
        print(gestionEnigme2.codesTrouver);
        Destroy(gameObject);
    }
}
