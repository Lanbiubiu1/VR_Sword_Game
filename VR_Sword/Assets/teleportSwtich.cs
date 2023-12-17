using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSwitch : MonoBehaviour
{   
    private CharacterController characterController;
    public GameObject teleportController;
    private LocomotionTeleport locomotionTeleport; 
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        
        if (teleportController != null)
        {
            locomotionTeleport = teleportController.GetComponent<LocomotionTeleport>();
        }
    }

    public void Disable()
    {
        characterController.enabled = false;
        locomotionTeleport.enabled = true;
        
    }

    public void Enable()
    {
        
        
        characterController.enabled = true;
        
        
       
        
        locomotionTeleport.enabled = false;
        
    }
}
