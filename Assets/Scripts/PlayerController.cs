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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(startCountdownRoutine());
        }
    }

    IEnumerator startCountdownRoutine()
    {
        yield return new WaitForSeconds(10);
        hasPowerup = false;
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
