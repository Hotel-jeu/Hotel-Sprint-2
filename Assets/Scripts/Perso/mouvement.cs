using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvement : MonoBehaviour
{
    // Référence à la caméra du joueur
    public Camera playerCamera;
    // Vitesse de marche, de course, et de marche accroupie
    private float walkSpeed = 4f;
    private float runSpeed = 5f;
    private float crouchSpeed = 2f;
    // Gravité appliquée au joueur
    private float gravity = 10f;

    // Sensibilité de la rotation et limites de rotation
    public float lookSpeed = 2f;
    public float lookXLimit = 10f;
    public float horizontalRotationLimit = 45f;

    // Direction du mouvement et rotations actuelles
    public Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    float rotationY = 0;

    // Booléens pour contrôler les actions du joueur
    public bool canMove = true;
    public bool canRotate = true;
    public bool dansPlacard = false;
    public bool delaiAction = false;

    // Vitesses actuelles sur les axes X et Y
    float curSpeedX;
    float curSpeedY;
    // Référence au CharacterController
    CharacterController characterController;

    // Références aux objets et sons
    public GameObject Main_Joueur;
    public GameObject Le_Placard;
    public AudioClip SonPlacardEntree;
    public AudioClip SonPlacardSortie;

    // Positions de la bibliothèque et de la garderie
    public GameObject PositionBiblio;
    public GameObject PositionGarderie;

    // Booléens statiques pour déterminer la position initiale
    static public bool De_Biblio = false;
    static public bool De_Garderie = false;

    // Méthode Start appelée au démarrage du script
    void Start()
    {
        // Initialiser le CharacterController et verrouiller le curseur
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Positionner le joueur selon les booléens statiques
        if (De_Biblio)
        {
            characterController.enabled = false;
            gameObject.transform.position = PositionBiblio.transform.position;
            characterController.enabled = true;
            De_Biblio = false;
        }
        else if (De_Garderie)
        {
            characterController.enabled = false;
            gameObject.transform.position = PositionGarderie.transform.position;
            characterController.enabled = true;
            De_Garderie = false;
        }
    }

    // Méthode Update appelée à chaque frame
    void Update()
    {
        // Si aucun UI n'est actif, permettre les contrôles du joueur
        if (!GestionJeuUI.UIActif)
        {
            float sensibiliteSouris = PlayerPrefs.GetFloat("MouseSensitivity", 0.5f);

            // Déterminer les directions de mouvement avant et droite
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            // Vérifier si le joueur est accroupi ou en train de courir
            bool isCrouching = Input.GetKey(KeyCode.LeftControl);
            bool isRunning = Input.GetKey(KeyCode.LeftShift);

            if (isCrouching)
            {
                // Définir les vitesses et la direction de mouvement en position accroupie
                curSpeedX = crouchSpeed * Input.GetAxis("Vertical");
                curSpeedY = crouchSpeed * Input.GetAxis("Horizontal");
                moveDirection = (forward * curSpeedX) + (right * curSpeedY);
                playerCamera.transform.localPosition = new Vector3(-0.13f, 0.2f, playerCamera.transform.localPosition.z);
            }
            else
            {
                // Définir les vitesses et la direction de mouvement en marche ou en course
                curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
                curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
                moveDirection = (forward * curSpeedX) + (right * curSpeedY);
                playerCamera.transform.localPosition = new Vector3(-0.13f, 0.395f, playerCamera.transform.localPosition.z);
            }

            // Appliquer la gravité
            moveDirection.y = -gravity;

            // Déplacer le joueur
            characterController.Move(moveDirection * Time.deltaTime);

            // Gérer la rotation du joueur
            if (canMove || canRotate)
            {
                // Rotation verticale
                rotationX += -Input.GetAxis("Mouse Y") * lookSpeed * sensibiliteSouris;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

                // Rotation horizontale
                rotationY += Input.GetAxis("Mouse X") * lookSpeed * sensibiliteSouris;
                if (dansPlacard)
                {
                    rotationY = Mathf.Clamp(rotationY, -horizontalRotationLimit, horizontalRotationLimit);
                }
                transform.localRotation = Quaternion.Euler(0, rotationY, 0);
            }

            // Si le joueur est dans un placard et appuie sur E, sortir du placard
            if (dansPlacard)
            {
                if (Input.GetKeyDown(KeyCode.E) && !delaiAction)
                {
                    ExitCloset();
                }
            }
        }
    }

    // Méthode pour entrer dans un placard
    public void EnterCloset()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(SonPlacardEntree);
        Le_Placard.GetComponent<Collider>().isTrigger = true;
        canMove = false;
        Main_Joueur.SetActive(false);
        dansPlacard = true;
        GetComponent<CharacterController>().enabled = false;
        gameObject.transform.position = new Vector3(Le_Placard.transform.position.x, Le_Placard.transform.position.y, Le_Placard.transform.position.z);
        GetComponent<CharacterController>().enabled = true;
        gameObject.transform.rotation = Le_Placard.transform.rotation;
        Le_Placard.tag = "Untagged";
        gameObject.tag = "Untagged";
        delaiAction = true;
        Invoke("arretDelai", 0.5f);
    }

    // Méthode pour sortir du placard
    public void ExitCloset()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(SonPlacardSortie);
        gameObject.transform.position = new Vector3(Le_Placard.transform.position.x, Le_Placard.transform.position.y, Le_Placard.transform.position.z + 1.5f);
        Le_Placard.GetComponent<Collider>().isTrigger = false;
        dansPlacard = false;
        canMove = true;
        Main_Joueur.SetActive(true);
        gameObject.tag = "player";
        Le_Placard.tag = "placard";
    }

    // Méthode pour arrêter le délai d'action
    void arretDelai()
    {
        delaiAction = false;
    }
}
