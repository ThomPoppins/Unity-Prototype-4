using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Enemy prefab to spawn
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefab, new Vector3(0, 0, 6), enemyPrefab.transform.rotation); // Spawn an enemy prefab at the spawn position
    }

    // Update is called once per frame
    void Update()
    {

    }
}
