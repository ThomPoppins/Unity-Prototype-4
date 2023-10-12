using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb; // Player's Rigidbody component
    private GameObject focalPoint; // Focal point for the camera
    public float speed = 5.0f; // Movement speed in meters per second
    public bool hasPowerup = false; // Powerup status
    private float powerupStrength = 15.0f; // Powerup strength
    public GameObject powerupIndicator; // Powerup indicator

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // Get the player's Rigidbody component
        focalPoint = GameObject.Find("Focal Point"); // Find the focal point
    }

    // Update is called once per frame
    void Update()
    {
        // Get the vertical input from the Input manager
        float forwardInput = Input.GetAxis("Vertical");
        // Move the player forward and backward in the forward direction of the focal point
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);

        // Set the powerup indicator position to the player's position with a slight offset on the y axis
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true); // Set the powerup indicator to active
            StartCoroutine(startCountdownRoutine()); // Start the countdown routine
        }
    }

    // Countdown coroutine
    IEnumerator startCountdownRoutine()
    {
        yield return new WaitForSeconds(10); // Wait for 10 seconds
        hasPowerup = false; // Set the powerup status to false
        powerupIndicator.gameObject.SetActive(false); // Set the powerup indicator to inactive
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>(); // Get the enemy's Rigidbody component
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position; // Get the direction away from the player

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse); // Apply a force away from the player
        }
    }
}
