using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2.0f; // Movement speed
    private Rigidbody enemyRb; // Enemy's Rigidbody component
    private GameObject player; // Player GameObject

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>(); // Get the enemy's Rigidbody component
        player = GameObject.Find("Player"); // Find the player GameObject
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized; // Get the direction from the enemy to the player

        enemyRb.AddForce(lookDirection * speed); // Move the enemy towards the player, normalized force
    }
}
