using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb; // Player's Rigidbody component
    private GameObject focalPoint; // Focal point for the camera
    public float speed = 5.0f; // Movement speed in meters per second
    public bool hasPowerup = false;

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
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Debug.Log("Player has collided with " + collision.gameObject + " with powerup set to " + hasPowerup);
        }
    }
}
