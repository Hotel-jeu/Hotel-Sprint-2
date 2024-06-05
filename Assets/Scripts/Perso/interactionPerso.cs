using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class interactionPerso : MonoBehaviour
{
    // Camera du joueur
    public Camera CameraJoueur;
    // Animator du perso
    private Animator AnimPerso;
    // Distance de ramassage
    public float ramasserDistance = 6f;
    // Image du curseur
    public Image curseurImage;
    // Couleur du curseur normalement
    public Color couleurCurseurNormal;
    // Taille du curseur normalement
    public float tailleCurseurNormal = 1f;
    // Vitesse à laquelle le curseur passe de mode normal à survol
    public float vitesse = 5f;
    // Couleur du curseur en survol
    public Color couleurCurseurSurvol;
    // Taille du curseur en survol
    public float tailleCurseurSurvol = 1.5f;
    // GameObject qui prend l'objet en focus par le raycast
    private GameObject objetEnFocus = null;
    // 
    private Coroutine changingCursorRoutine = null;

    private AudioSource sourceAudio;
    public AudioClip prendreObjet;
    public AudioClip prendrePapier;

    public InventoryManager inventoryManager;
    public Item LampeItem;
    public Item CanetteItem;
    public Item BouteilleItem;

    public Gestion_Garderie Gestion_Garderie;
    public Gestion_Feedback Gestion_Feedback;
    public List<GameObject> Garderie_Vies = new List<GameObject>();
    public AudioClip SonPerteVie;
    public Light Lumiere_Retour;

    // Start is called before the first frame update
    void Start() 
    { 
        sourceAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        
        // Raccourcit le code plus tard
        AnimPerso = GetComponent<Animator>();
        // Lance la fonction raycast
        RayCast();
    }

    void RayCast()
    {
        // Rayon de la caméra vers la souris (Droit devant vu la souris est au milieu et locked)
        Ray ray = CameraJoueur.ScreenPointToRay(Input.mousePosition);
        // Objet qui est hit par le rayon
        RaycastHit hit;

        Debug.DrawLine(ray.origin, ray.origin + ray.direction * ramasserDistance, Color.green);

        // Si le rayon qui a la longueur de ramasserDistance touche un truc, ça met l'objet dans hit
        if (Physics.Raycast(ray, out hit, ramasserDistance))
        {

            // Si l'objet hit a un tag porte
            if (hit.collider.CompareTag("porte"))
            {   
                // Store l'objet dans objetEnFocus pour pouvoir l'utiliser
                getObjet(hit.collider.gameObject);
                // Change le curseur en mode survol
                ChangerCurseur(couleurCurseurSurvol, tailleCurseurSurvol);

                // Si on appuie sur E, bascule l'état de la porte (qui vient d'un autre script)
                if (Input.GetKeyDown(KeyCode.E))
                {
                    objetEnFocus.GetComponentInParent<scripTestPorte>().TogglePorte();
                   // audioSource.PlayOneShot(porteOuvre);

                }
            }
            // Si l'objet hit a un tag torche
            else if (hit.collider.CompareTag("torche"))
            {
                // Store l'objet dans objetEnFocus pour pouvoir l'utiliser
                getObjet(hit.collider.gameObject);
                // Change le curseur en mode survol
                ChangerCurseur(couleurCurseurSurvol, tailleCurseurSurvol);
                // Active le texte de la torche
                

                // Change le statut de possession de la torche a true, l'active dans l'inventaire
                // Désactive la lampe torche qu'on vient de prendre, et enlève le texte
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Appelle AddItem du gestionnaire d'inventaire, et lui donne l'item à ajouter
                    bool resultat = inventoryManager.AddItem(LampeItem);
                    // Si le résultat de cet essai est true (L'objet a été ajouté)
                    if(resultat) {
                        // Joue le son de prise d'objet
                        sourceAudio.PlayOneShot(prendreObjet);
                        // Désactive l'objet pris
                        objetEnFocus.SetActive(false);
                    }
                    // Sinon rien se passe, l'inventaire est plein
                    else {
                        Debug.Log("InventairePlein");
                    }  
                }
            }
            // Si l'objet hit a un tag canette
            else if (hit.collider.CompareTag("canette"))
            {
                // Store l'objet dans objetEnFocus pour pouvoir l'utiliser
                getObjet(hit.collider.gameObject);
                // Change le curseur en mode survol
                ChangerCurseur(couleurCurseurSurvol, tailleCurseurSurvol);

                // Si on appuie sur E 
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Appelle AddItem du gestionnaire d'inventaire, et lui donne l'item à ajouter
                    bool resultat = inventoryManager.AddItem(CanetteItem);
                    // Si le résultat de cet essai est true (L'objet a été ajouté)
                    if (resultat) {
                        // Joue le son de prise d'objet
                        sourceAudio.PlayOneShot(prendreObjet);
                        // Désactive l'objet pris
                        objetEnFocus.SetActive(false);
                    } 
                    // Sinon rien se passe, l'inventaire est plein
                    else {
                        Debug.Log("InventairePlein");
                    }
                    
                }
            }
            // Si l'objet hit a un tag bouteille
            else if (hit.collider.CompareTag("bouteille"))
            {
                // Store l'objet dans objetEnFocus pour pouvoir l'utiliser
                getObjet(hit.collider.gameObject);
                // Change le curseur en mode survol
                ChangerCurseur(couleurCurseurSurvol, tailleCurseurSurvol);

                // Si on appuie sur E 
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Appelle AddItem du gestionnaire d'inventaire, et lui donne l'item à ajouter
                    bool resultat = inventoryManager.AddItem(BouteilleItem);
                    // Si le résultat de cet essai est true (L'objet a été ajouté)
                    if (resultat) {
                        // Joue le son de prise d'objet
                        sourceAudio.PlayOneShot(prendreObjet);
                        // Désactive l'objet pris
                        objetEnFocus.SetActive(false);
                    } 
                    // Sinon rien se passe, l'inventaire est plein
                    else {
                        Debug.Log("InventairePlein");
                    }
                    
                }
            }
            // Si l'objet hit a un tag code
            else if (hit.collider.CompareTag("code"))
            {
                // Store l'objet dans objetEnFocus pour pouvoir l'utiliser
                getObjet(hit.collider.gameObject);
                // Change le curseur en mode survol
                ChangerCurseur(couleurCurseurSurvol, tailleCurseurSurvol);


                // Si on appuie sur E 
                if (Input.GetKeyDown(KeyCode.E))
                {
                    sourceAudio.PlayOneShot(prendrePapier);
                    // Appelle ActiverCode du script activationCode du code qui vient d'être pris
                    objetEnFocus.GetComponent<activationCode>().ActiverCode();
                }
            }
            else if (hit.collider.CompareTag("photoPrendre"))
            {
                // Store l'objet dans objetEnFocus pour pouvoir l'utiliser
                getObjet(hit.collider.gameObject);
                // Change le curseur en mode survol
                ChangerCurseur(couleurCurseurSurvol, tailleCurseurSurvol);


                if (Input.GetKeyDown(KeyCode.E)) {
                    sourceAudio.PlayOneShot(prendrePapier);
                    objetEnFocus.GetComponent<activationPhoto>().ActiverPhoto();
                }
                
            }
            else if (hit.collider.CompareTag("difference")) {

                getObjet(hit.collider.gameObject);
                ChangerCurseur(couleurCurseurSurvol, tailleCurseurSurvol);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    objetEnFocus.GetComponent<Gestion_Differences>().CorrigerErreur();
                    StartCoroutine(Gestion_Feedback.ClignotementLumiere(Color.green));
                    Gestion_Garderie.differences_trouver++;
                    
                    Debug.Log(Gestion_Garderie.differences_trouver);
                }
                
            }
            else if (hit.collider.CompareTag("erreur")) {
                
                getObjet(hit.collider.gameObject);
                ChangerCurseur(couleurCurseurSurvol, tailleCurseurSurvol);

                if (Input.GetKeyDown(KeyCode.E))
                {   
                    Une_Vie_Fini();


                    StartCoroutine(Gestion_Feedback.ClignotementLumiere(Color.red));
                    Gestion_Garderie.erreurs_commises++;
                    objetEnFocus.tag = "Untagged";
                    Debug.Log(Gestion_Garderie.erreurs_commises);
                }
                
            }
            else if (hit.collider.CompareTag("placard")) {
                getObjet(hit.collider.gameObject);
                ChangerCurseur(couleurCurseurSurvol, tailleCurseurSurvol);

                if (Input.GetKeyDown(KeyCode.E)) {
                    gameObject.GetComponent<mouvement>().Le_Placard = objetEnFocus;
                    gameObject.GetComponent<mouvement>().EnterCloset();

                    
                }
            }
            // Si l'objet touché n'a pas un tag pris en charge
            else
            {
                // Remet le curseur dans son état normal
                ChangerCurseur(couleurCurseurNormal, tailleCurseurNormal);
                // Et si y'a un objet en Focus, le reset
                if (objetEnFocus != null)
                {
                    objetEnFocus = null;
                }
            }

        }
        // Si aucun objet n'est touché par le rayon
        else
        {   
            // Remet le curseur dans son état normal
            ChangerCurseur(couleurCurseurNormal, tailleCurseurNormal);
             // Et si y'a un objet en Focus, le reset
            if (objetEnFocus != null)
            {
                objetEnFocus = null;
            }        
        }
    }




    // Gestion objet en focus
    void getObjet(GameObject objetHit)
    {
        // Met l'objet qui est hit en objetEnFocus
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
    public void Une_Vie_Fini() {
        if (Garderie_Vies.Count > 0) {
            GetComponent<AudioSource>().PlayOneShot(SonPerteVie);
            GameObject Vie = Garderie_Vies[Garderie_Vies.Count - 1];
            Garderie_Vies.RemoveAt(Garderie_Vies.Count - 1);
            Destroy(Vie);
        }
        
    }
}
