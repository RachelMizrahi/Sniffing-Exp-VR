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

    private static int answerIndex1 = 1;
    private static int answerIndex2 = 1;

    // Reference to the sound clip
    public AudioClip collisionSound;

    // Flash effect duration and color
   // public Color flashColor = Color.yellow;
   // public float flashDuration = 0.3f;

    void Start()
    {
        // Get the audio source component attached to the object
        audioSource = GetComponent<AudioSource>();

        // If no AudioSource is attached, add one dynamically
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the collision sound to the AudioSource
        if (collisionSound != null)
        {
            audioSource.clip = collisionSound;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("object entered trigger");

        // Check if the object collided with a collider that has the tag "Answer Collider"
        if (other.CompareTag("Answer Collider"))
        {
            // Play the collision sound if available
            if (audioSource != null && collisionSound != null)
            {
                audioSource.PlayOneShot(collisionSound);
            }

            // Flash the correct answer
           // if (other.gameObject.name == AnswerText1.name)
          //  {
          //      StartCoroutine(FlashText(AnswerText1));
          //  }
          //  else if (other.gameObject.name == AnswerText2.name)
          //  {
          //      StartCoroutine(FlashText(AnswerText2));
          //  }

            // Increment the object counter
            objectCounter++;
            Debug.Log("object counter updated: " + objectCounter);

            // Check if 8 objects have been placed
            if (objectCounter >= 8)
            {
                Debug.Log("changing answers - objectCounter: " + objectCounter);
                // Change the answers (after 8 objects)
                ChangeAnswers();

                // Reset the counter for the next round
                objectCounter = 0;
            }

            // Instantiate a new object on the table at the specific appear position
            Instantiate(objectPrefab, appearPosition.position, Quaternion.identity);

            // If the object enters the trigger area, destroy it
            Destroy(gameObject);
        }
    }

    // Function to make the text flash
    //IEnumerator FlashText(TMP_Text answerText)
    //{
        //Color originalColor = answerText.color; // Store original color

        // Change to flash color
       // answerText.color = flashColor;

        // Wait for the duration
      //  yield return new WaitForSeconds(flashDuration);

        // Return to original color
     //   answerText.color = originalColor;
   // }

    // Function to change the first answer text
    void ChangeAnswers()
    {
        // Make sure the array has more than one question
        if (answers1.Length > 0 && answers2.Length > 0)
        {
            // Pick a random question or select the next one (depending on your preference)
            AnswerText1.text = answers1[answerIndex1];
            AnswerText2.text = answers2[answerIndex2];

            answerIndex1 = (answerIndex1 + 1);
            answerIndex2 = (answerIndex2 + 1);
        }
    }
}