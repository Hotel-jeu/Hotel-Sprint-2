using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class SceneApresCinematique : MonoBehaviour
{
    // La video de la cinematique
    public VideoPlayer Cinematique;

    // Start is called before the first frame update
    void Start()
    {   
        // Une fois rendu a la fin de la video, on appelle VideoFiniAction sur la cinematique
        Cinematique.loopPointReached += VideoFiniAction;
    }


    // On charge la scene tuto
    private void VideoFiniAction(VideoPlayer cinematique) {
        SceneManager.LoadScene("Tuto");
    }
    public void IgnorerCinematique() {
        SceneManager.LoadScene("Tuto");
    }
}
