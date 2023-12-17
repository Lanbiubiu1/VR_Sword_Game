using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawned : MonoBehaviour
{
    public GameObject Object;
    

    private OVRCameraRig overCameraRig;
    private GameObject instantiatedObject;
    

    void Start()
    {
        overCameraRig = FindObjectOfType<OVRCameraRig>();

        if (overCameraRig == null)
        {
            Debug.LogError("OVRCameraRig not found in the scene!");
        }
    }

    public void SetObject() {
        Vector3 cameraPos = overCameraRig.centerEyeAnchor.position;
        Vector3 cameraForward = overCameraRig.centerEyeAnchor.forward;

        instantiatedObject = Instantiate(Object);
        instantiatedObject.transform.SetParent(overCameraRig.centerEyeAnchor, false);

        instantiatedObject.transform.localPosition = new Vector3(0, 0, 0.5f);
        instantiatedObject.transform.localRotation = Quaternion.identity;
        
         
        
    }

    public void CloseMenu() {
        GameObject[] menus = GameObject.FindGameObjectsWithTag("Menu");

        for (int i = 1; i < menus.Length; i++) {
            Destroy(menus[i]);
        }
    }
 
}
