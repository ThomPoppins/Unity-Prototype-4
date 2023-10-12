using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Enemy prefab to spawn
    private float spawnRange = 9.0f; // Spawn range
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(); // Spawn the enemy wave
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Spawn enemy wave
    void SpawnEnemyWave()
    {
        for (int i = 0; i < 3; i++) // Spawn 3 enemies
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation); // Spawn an enemy prefab at the spawn position
        }
    }

    private Vector3 GenerateSpawnPosition() // Generate a random spawn position
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange); // Randomize the spawn position on the x axis
        float spawnPosZ = Random.Range(-spawnRange, spawnRange); // Randomize the spawn position on the z axis

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ); // Create a spawn position Vector3

        return randomPos; // Return the spawn position
    }
}
