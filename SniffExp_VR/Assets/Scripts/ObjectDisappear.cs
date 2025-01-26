using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisappear : MonoBehaviour
{
    // Reference to the audio source component
    private AudioSource audioSource;

    // Reference to the prefab of the object that will be shown next
    public GameObject objectPrefab;

    // The position on the table where the object should appear
    public Transform appearPosition;
    
    // This function is called when the object enters a trigger collider
    void Start()
    {
        // Get the audio source component attached to the object
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object collided with a collider that has the tad "Answer Collider"
        if (other.CompareTag("Answer Collider"))
        {
            // Play the sound
            if (audioSource != null)
            {
                audioSource.Play();

            }

            // If the object enters the trigger area, destroy it
            Destroy(gameObject);

            // Instantiate a new object on the table at the specific apear position
            Instantiate(objectPrefab, appearPosition.position, Quaternion.identity);
        }
                
    }

}
