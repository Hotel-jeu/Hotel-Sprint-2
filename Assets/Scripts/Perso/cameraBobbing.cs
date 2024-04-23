using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBobbing : MonoBehaviour
{
    private Animator cameraBob;
    void Start()
    {
        cameraBob = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            cameraBob.SetBool("cameraBobbingBoolCrouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            cameraBob.SetBool("cameraBobbingBoolCrouch", false);
        }
        else if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D)))
        {
            cameraBob.SetBool("cameraBobbingBoolMarche", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            cameraBob.SetBool("cameraBobbingBoolMarche", false);
        }
    }
}