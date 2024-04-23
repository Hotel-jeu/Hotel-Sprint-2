using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lampe : MonoBehaviour
{
    public GameObject lampeTorche;

    public AudioSource audioSource;
    public AudioClip sonLampe;

    private void Update()
    {   
        if (Input.GetMouseButtonDown(0) && !GestionJeuUI.UIActif)
        {
            lampeTorche.SetActive(!lampeTorche.activeSelf);
            audioSource.PlayOneShot(sonLampe);
        }
    }
}
