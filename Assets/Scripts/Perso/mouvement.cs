using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvement : MonoBehaviour
{
    public Camera playerCamera;
    private float walkSpeed = 4f;
    private float runSpeed = 5f;
    private float crouchSpeed = 2f;
    private float gravity = 10f;


    public float lookSpeed = 2f;
    public float lookXLimit = 45f;


    public Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;

    float curSpeedX;
    float curSpeedY;
    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {   


        if (!GestionJeuUI.UIActif) {
            float sensibiliteSouris = PlayerPrefs.GetFloat("MouseSensitivity", 0.5f);

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isCrouching = Input.GetKey(KeyCode.LeftControl);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        if (isCrouching)
        {
            
            curSpeedX = crouchSpeed  * Input.GetAxis("Vertical");
            curSpeedY = crouchSpeed  * Input.GetAxis("Horizontal");
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);
            playerCamera.transform.localPosition = new Vector3(-0.13f,0.2f,-0.339f);
        }
        else
        {
            curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
            curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);
            playerCamera.transform.localPosition = new Vector3(-0.13f, 0.395f, -0.339f);
        }



        float movementDirectionY = moveDirection.y;
        // moveDirection.y = movementDirectionY;
        // moveDirection.y -= gravity * Time.deltaTime;
        moveDirection.y = -gravity;

        characterController.Move(moveDirection * Time.deltaTime);


        // Sensibilite souris vient du script GestionParametre
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed * sensibiliteSouris;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed * sensibiliteSouris, 0);
        }
        }
        
    }
}
