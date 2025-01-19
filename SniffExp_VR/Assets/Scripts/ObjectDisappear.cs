using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisappear : MonoBehaviour
{
    public GameObject objectToDisappear;  // The object that will disappear
    public string[] triggerTags;  // Tags for areas that trigger the object disappearance

    // Called when another collider enters the trigger area
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered has one of the tags specified in triggerTags
        foreach (string tag in triggerTags)
        {
            if (other.CompareTag(tag))  // Compare the collider's tag
            {
                // If the object to disappear is assigned, deactivate it
                if (objectToDisappear != null)
                {
                    objectToDisappear.SetActive(false);  // Disable the object
                }
            }
        }
    }
}
