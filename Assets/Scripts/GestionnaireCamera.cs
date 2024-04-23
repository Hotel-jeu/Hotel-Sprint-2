using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionnaireCamera : MonoBehaviour

{
    public GameObject[] lesCams;


    // Start is called before the first frame update
    void Start()
    {
        ActiveCam(0);

    }

    public void ActiveCam(int indexCamActive)
    {
        if (indexCamActive < 0 || indexCamActive >= lesCams.Length) {
            return;
        }

        foreach (GameObject cam in lesCams)
        {
            cam.SetActive(false);
        }

        lesCams[indexCamActive].SetActive(true);
    }
}
