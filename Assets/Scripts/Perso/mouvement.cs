using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvement : MonoBehaviour
{
    // R�f�rence � la cam�ra du joueur
    public Camera playerCamera;
    // Vitesse de marche, de course, et de marche accroupie
    private float walkSpeed = 4f;
    private float runSpeed = 5f;
    private float crouchSpeed = 2f;
    // Gravit� appliqu�e au joueur
    private float gravity = 10f;

    // Sensibilit� de la rotation et limites de rotation
    public float lookSpeed = 2f;
    public float lookXLimit = 10f;
    public float horizontalRotationLimit = 45f;

    // Direction du mouvement et rotations actuelles
    public Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    float rotationY = 0;

    // Bool�ens pour contr�ler les actions du joueur
    public bool canMove = true;
    public bool canRotate = true;
    public bool dansPlacard = false;
    public bool delaiAction = false;

    // Vitesses actuelles sur les axes X et Y
    float curSpeedX;
    float curSpeedY;
    // R�f�rence au CharacterController
    CharacterController characterController;

    // R�f�rences aux objets et sons
    public GameObject Main_Joueur;
    public GameObject Le_Placard;
    public AudioClip SonPlacardEntree;
    public AudioClip SonPlacardSortie;

    // Positions de la biblioth�que et de la garderie
    public GameObject PositionBiblio;
    public GameObject PositionGarderie;

    // Bool�ens statiques pour d�terminer la position initiale
    static public bool De_Biblio = false;
    static public bool De_Garderie = false;

    // M�thode Start appel�e au d�marrage du script
    void Start()
    {
        // Initialiser le CharacterController et verrouiller le curseur
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Positionner le joueur selon les bool�ens statiques
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

    // M�thode Update appel�e � chaque frame
    void Update()
    {
        // Si aucun UI n'est actif, permettre les contr�les du joueur
        if (!GestionJeuUI.UIActif)
        {
            float sensibiliteSouris = PlayerPrefs.GetFloat("MouseSensitivity", 0.5f);

            // D�terminer les directions de mouvement avant et droite
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            // V�rifier si le joueur est accroupi ou en train de courir
            bool isCrouching = Input.GetKey(KeyCode.LeftControl);
            bool isRunning = Input.GetKey(KeyCode.LeftShift);

            if (isCrouching)
            {
                // D�finir les vitesses et la direction de mouvement en position accroupie
                curSpeedX = crouchSpeed * Input.GetAxis("Vertical");
                curSpeedY = crouchSpeed * Input.GetAxis("Horizontal");
                moveDirection = (forward * curSpeedX) + (right * curSpeedY);
                playerCamera.transform.localPosition = new Vector3(-0.13f, 0.2f, playerCamera.transform.localPosition.z);
            }
            else
            {
                // D�finir les vitesses et la direction de mouvement en marche ou en course
                curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
                curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
                moveDirection = (forward * curSpeedX) + (right * curSpeedY);
                playerCamera.transform.localPosition = new Vector3(-0.13f, 0.395f, playerCamera.transform.localPosition.z);
            }

            // Appliquer la gravit�
            moveDirection.y = -gravity;

            // D�placer le joueur
            characterController.Move(moveDirection * Time.deltaTime);

            // G�rer la rotation du joueur
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

    // M�thode pour entrer dans un placard
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

    // M�thode pour sortir du placard
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

    // M�thode pour arr�ter le d�lai d'action
    void arretDelai()
    {
        delaiAction = false;
    }
}
