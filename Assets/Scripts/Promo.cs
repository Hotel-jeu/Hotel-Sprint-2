using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Promo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("ImageCurseur").GetComponent<RectTransform>().sizeDelta = new Vector2(0f,0f);
        GameObject.Find("ImageCurseur").transform.localScale *= 0f;
        GameObject.Find("fpsarms").transform.localScale *= 0f;

        if (Input.GetKeyDown(KeyCode.Keypad1)) {
            SceneManager.LoadScene("Tuto");
        } else if (Input.GetKeyDown(KeyCode.Keypad2)) {
            SceneManager.LoadScene("Etage2");
        } else if (Input.GetKeyDown(KeyCode.Keypad3)) {
            SceneManager.LoadScene("Etage1");
        } else if (Input.GetKeyDown(KeyCode.Keypad4)) {
            SceneManager.LoadScene("Garderie");
        } else if (Input.GetKeyDown(KeyCode.Keypad5)) {
            SceneManager.LoadScene("biblio");
        } else if (Input.GetKeyDown(KeyCode.Keypad6)) {
            SceneManager.LoadScene("Etage0");
        }
    }
    
}
