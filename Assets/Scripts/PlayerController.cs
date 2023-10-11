using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb; // Player's Rigidbody component
    public float speed = 5.0f; // Movement speed in meters per second

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // Get the player's Rigidbody component
    }

    // Update is called once per frame
    void Update()
    {
        // Get the vertical input from the Input manager
        float forwardInput = Input.GetAxis("Vertical");
        // Move the player forward and backward
        playerRb.AddForce(Vector3.forward * forwardInput * speed);
    }
}
