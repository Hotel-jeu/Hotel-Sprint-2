using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionEnigme2 : MonoBehaviour
{
    static public float codesTrouver = 0;
    public GameObject ascenseurSortie;
    public GameObject GestionnaireCamera;

    private bool enigmeFini = false;
    void Start()
    {
        codesTrouver = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (codesTrouver == 6 && !enigmeFini) {
            ascenseurSortie.GetComponent<Animator>().SetBool("ouvrirAscenseur", true);
            GestionnaireCamera.GetComponent<GestionnaireCamera>().ActiveCam(1);
            enigmeFini = true;
            Invoke("ReactiverCamJoueur", 1.5f);
        }
    }

    void ReactiverCamJoueur() {
        GestionnaireCamera.GetComponent<GestionnaireCamera>().ActiveCam(0);
    }
}
