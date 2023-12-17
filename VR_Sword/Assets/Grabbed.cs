using UnityEngine;

public class Grabbed : MonoBehaviour
{
    public GameObject sword;
    private Rigidbody swordRigidbody;

    void Start()
    {
        // Ensure the sword has a Rigidbody component attached
        swordRigidbody = sword.GetComponent<Rigidbody>();

        // Optionally, ensure the sword's collider is set as a trigger
        // Collider swordCollider = sword.GetComponent<Collider>();
        // swordCollider.isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered the trigger is the controller or hand
        // You may want to use tags or other conditions to verify this
        if (other.CompareTag("Player"))
        {
            // If the sword is grabbed, disable gravity
            if (swordRigidbody != null)
            {
                swordRigidbody.useGravity = true;
            }
        }
    }

    
}
