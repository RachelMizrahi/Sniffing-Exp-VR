using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ObjectDisappear : MonoBehaviour
{
    // Reference to the audio source component
    private AudioSource audioSource;

    // Reference to the prefab of the object that will be shown next
    public GameObject objectPrefab;

    // The position on the table where the object should appear
    public Transform appearPosition;

    // Reference to the text component for the answers
    public TMP_Text AnswerText1;
    public TMP_Text AnswerText2;

    // List of answers to display
    public string[] answers1;
    public string[] answers2;

    // counter for the number of objects thet have been placed
    private static int objectCounter = 0;

    // This function is called when the object enters a trigger collider
    void Start()
    {
        // Get the audio source component attached to the object
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("object entered trigger");
        // Check if the object collided with a collider that has the tad "Answer Collider"
        if (other.CompareTag("Answer Collider"))
        {
            // Increment the object counter
            objectCounter++;
            Debug.Log("object counter updated:" + objectCounter);

            // Play the sound
            if (audioSource != null)
            {
                audioSource.Play();
            }
                   
            // If the object enters the trigger area, destroy it
            Destroy(gameObject);
             
            // Check if 8 objects have been placed
            if (objectCounter >= 8)
            {
                Debug.Log("changing answers - objectCounter" + objectCounter);
                // Change the answers (after 8 objects)
                ChangeAnswers();

                // Reset the counter for the next round
                objectCounter = 0;
            }

            // Instantiate a new object on the table at the specific apear position
            Instantiate(objectPrefab, appearPosition.position, Quaternion.identity);
        }

    }

    // Function to change the first answer text
    void ChangeAnswers()
    {
        // Make sure the array has more than one question
        if (answers1.Length > 0)
        {
            // Pick a random question or select the next one (depending on your preference)
            string newAnswer1 = answers1[Random.Range(0, answers1.Length)];
            string newAnswer2 = answers2[Random.Range(0, answers2.Length)];
            // Change the question text in the UI
            AnswerText1.text = newAnswer1;
            AnswerText2.text = newAnswer2;
        }
        
    }

}
