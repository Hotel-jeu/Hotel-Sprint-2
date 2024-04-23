using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class interactionPerso : MonoBehaviour
{

    public Camera CameraJoueur;
    private Animator AnimPerso;
    public float ramasserDistance = 6f;

    public Image curseurImage;

    public Color couleurCurseurNormal;
    public float tailleCurseurNormal = 1f;
    public float vitesse = 5f;

    public Color couleurCurseurSurvol;
    public float tailleCurseurSurvol = 1.5f;

    private GameObject objetEnFocus = null;
    private Coroutine changingCursorRoutine = null;

    static bool lampeTorcheBool = false;

    public AudioSource audioSource;
    public AudioClip porteOuvre, porteFerme;

    static bool lampeTorcheBoolCanvas = false;
    public GameObject lampeTorcheGO;
    public GameObject lampeTorcheGOCanvas;

    public static int nbCanette = 0;
    public static int nbBouteille = 0;

    static bool canetteBoolCanvas = false;
    static bool bouteilleBoolCanvas = false;
    public GameObject canetteGO;
    public GameObject bouteilleGO;

    public TextMeshProUGUI textCan;
    public TextMeshProUGUI textBou;

    public GameObject textLampe;
    public GameObject textPorteSorti;

    // Start is called before the first frame update
    void Start() { 
 
    }

    // Update is called once per frame
    void Update()
    {
        AnimPerso = GetComponent<Animator>();

        RayCast();

        lampeTorcheGO.SetActive(lampeTorcheBool);
        lampeTorcheGOCanvas.SetActive(lampeTorcheBoolCanvas);

        canetteGO.SetActive(canetteBoolCanvas);
        bouteilleGO.SetActive(bouteilleBoolCanvas);

        if (nbCanette > 0)
        {
            textCan.text = "x" + nbCanette.ToString();
        }
        else
        {
            textCan.text = "";
        }
        if (nbBouteille > 0)
        {
            textBou.text = "x" + nbBouteille.ToString();
        }
        else
        {
            textBou.text = "";
        }
    }

    void RayCast()
    {
        Ray ray = CameraJoueur.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        Debug.DrawLine(ray.origin, ray.origin + ray.direction * ramasserDistance, Color.green);


        if (Physics.Raycast(ray, out hit, ramasserDistance))
        {
            if (hit.collider.CompareTag("porte"))
            {
                getObjet(hit.collider.gameObject);
                ChangerCurseur(couleurCurseurSurvol, tailleCurseurSurvol);


                if (Input.GetKeyDown(KeyCode.E))
                {
                    objetEnFocus.GetComponentInParent<scripTestPorte>().TogglePorte();
                    audioSource.PlayOneShot(porteOuvre);

                }
            }
            else if (hit.collider.CompareTag("porteSorti"))
            {
                getObjet(hit.collider.gameObject);
                ChangerCurseur(couleurCurseurSurvol, tailleCurseurSurvol);


                if (lampeTorcheBool == true && Input.GetKeyDown(KeyCode.E))
                {
                    objetEnFocus.GetComponentInParent<scripTestPorte>().TogglePorte();
                    audioSource.PlayOneShot(porteOuvre);
                    textPorteSorti.SetActive(false);
                }
                else
                {
                    if (!lampeTorcheBool)
                    {
                        textPorteSorti.SetActive(true);
                    }
                }
            }
            else if (hit.collider.CompareTag("torche"))
            {
                getObjet(hit.collider.gameObject);
                ChangerCurseur(couleurCurseurSurvol, tailleCurseurSurvol);
                textLampe.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    lampeTorcheBool = true;
                    lampeTorcheBoolCanvas = true;
                    objetEnFocus.SetActive(false);
                    textLampe.SetActive(false);


                }
            }
            else if (hit.collider.CompareTag("canette"))
            {
                getObjet(hit.collider.gameObject);
                ChangerCurseur(couleurCurseurSurvol, tailleCurseurSurvol);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    objetEnFocus.SetActive(false);
                    if (!canetteBoolCanvas)
                    {
                        canetteBoolCanvas = true;
                        nbCanette = 1;
                    }
                    else if (canetteBoolCanvas)
                    {
                        nbCanette++;
                    }
                }
            }
            else if (hit.collider.CompareTag("bouteille"))
            {
                getObjet(hit.collider.gameObject);
                ChangerCurseur(couleurCurseurSurvol, tailleCurseurSurvol);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    objetEnFocus.SetActive(false);
                    if (!bouteilleBoolCanvas)
                    {
                        bouteilleBoolCanvas = true;
                        nbBouteille = 1;
                    }
                    else if (bouteilleBoolCanvas)
                    {
                        nbBouteille++;
                    }
                }
            }
            else if (hit.collider.CompareTag("code"))
            {
                getObjet(hit.collider.gameObject);
                ChangerCurseur(couleurCurseurSurvol, tailleCurseurSurvol);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    objetEnFocus.GetComponent<activationCode>().ActiverCode();
                }
            }
            else
            {
                ChangerCurseur(couleurCurseurNormal, tailleCurseurNormal);
                if (objetEnFocus != null)
                {
                    objetEnFocus = null;
                }
            }

        }
        else
        {
            ChangerCurseur(couleurCurseurNormal, tailleCurseurNormal);
            if (objetEnFocus != null)
            {
                objetEnFocus = null;
            }
            if (SceneManager.GetActiveScene().name == "tuto") {
                textLampe.SetActive(false);
                textPorteSorti.SetActive(false);
            }
            
            
        }
    }




    // Gestion objet en focus
    void getObjet(GameObject objetHit)
    {
        if (objetEnFocus != objetHit)
        {
            objetEnFocus = objetHit;
        }
    }

    // Gestion du changement de curseur
    void ChangerCurseur(Color nouvelleCouleur, float nouvelleTaille)
    {

        if (changingCursorRoutine != null)
        {
            StopCoroutine(changingCursorRoutine);
        }
        changingCursorRoutine = StartCoroutine(AnimerChangementCurseur(nouvelleCouleur, nouvelleTaille));
    }
    IEnumerator AnimerChangementCurseur(Color nouvelleCouleur, float nouvelleTaille)
    {

        while (curseurImage.color != nouvelleCouleur || curseurImage.transform.localScale.x != nouvelleTaille)
        {
            curseurImage.color = Color.Lerp(curseurImage.color, nouvelleCouleur, Time.deltaTime * vitesse);
            curseurImage.transform.localScale = Vector3.Lerp(curseurImage.transform.localScale, new Vector3(nouvelleTaille, nouvelleTaille, nouvelleTaille), Time.deltaTime * vitesse);
            yield return null;
        }
    }
}
