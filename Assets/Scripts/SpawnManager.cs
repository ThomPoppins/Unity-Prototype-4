using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Enemy prefab to spawn
    public GameObject hardEnemyPrefab; // Hard enemy prefab to spawn
    public GameObject powerupPrefab; // Powerup prefab to spawn
    public GameObject firePowerupPrefab; // Fire powerup prefab to spawn
    private float spawnRange = 9.0f; // Spawn range
    private int enemyCount; // Enemy count
    private int waveNumber = 1; // Wave number

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber); // Spawn the enemy wave
        SpawnPowerup(); // Spawn a powerup
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length; // Get the enemy count

        if (enemyCount == 0) // If there are no enemies
        {
            waveNumber++; // Increment the wave number
            SpawnEnemyWave(waveNumber); // Spawn an enemy wave with the amount equal to new wave number
            SpawnPowerup(); // Spawn a powerup
        }
    }

    void SpawnPowerup()
    {
        if (Random.Range(0f, 10f) < 5.0f) // 50% chance to spawn a powerup
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); // Spawn an powerup prefab at the spawn position
        }
        else
        {
            Instantiate(firePowerupPrefab, GenerateSpawnPosition(), firePowerupPrefab.transform.rotation); // Spawn an fire powerup prefab at the spawn position
        }
    }

    // Spawn enemy wave
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++) // Spawn enemies
        {
            if (spawnHardEnemy()) // If the enemy is hard
            {
                Instantiate(hardEnemyPrefab, GenerateSpawnPosition(), hardEnemyPrefab.transform.rotation); // Spawn a hard enemy prefab at the spawn position
            }
            else
            {
                Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation); // Spawn an enemy prefab at the spawn position
            }
        }
    }

    // Spawn hard enemy?
    private bool spawnHardEnemy()
    {
        if (Random.Range(0f, 10f) < 2.5f)
        {
            return true;
        }
        return false;
    }


    private Vector3 GenerateSpawnPosition() // Generate a random spawn position
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange); // Randomize the spawn position on the x axis
        float spawnPosZ = Random.Range(-spawnRange, spawnRange); // Randomize the spawn position on the z axis

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ); // Create a spawn position Vector3

        return randomPos; // Return the spawn position
    }
}
