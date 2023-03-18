/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    public TextMesh waveCounter;
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public float spawnInterval = 1f; // The interval between enemy spawns
    public int maxEnemiesPerWave = 10; // The maximum number of enemies per wave
    public float waveInterval = 5f; // The interval between waves

    private int currentWave = 0; // The current wave number
    private int enemiesSpawned = 0; // The number of enemies spawned in the current wave

    private void Start()
    {
        UpdateWaveCounter();
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (currentWave < maxEnemiesPerWave)
        {
            if (enemiesSpawned < maxEnemiesPerWave)
            {
                // Spawn an enemy
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                enemiesSpawned++;
            }
            else
            {
                // Wait for the next wave
                yield return new WaitForSeconds(waveInterval);
                currentWave++;
                enemiesSpawned = 0;
                UpdateWaveCounter();
            }

            // Wait for the next enemy spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void UpdateWaveCounter()
    {
        waveCounter.text = "Wave: " + currentWave;
    }
}
*/









/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public float spawnInterval = 1f; // The interval between enemy spawns
    public int maxEnemiesPerWave = 10; // The maximum number of enemies per wave
    public float waveInterval = 5f; // The interval between waves

    private int currentWave = 0; // The current wave number
    private int enemiesSpawned = 0; // The number of enemies spawned in the current wave

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (currentWave < maxEnemiesPerWave)
        {
            if (enemiesSpawned < maxEnemiesPerWave)
            {
                // Spawn an enemy
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                enemiesSpawned++;
            }
            else
            {
                // Wait for the next wave
                yield return new WaitForSeconds(waveInterval);
                currentWave++;
                enemiesSpawned = 0;
            }

            // Wait for the next enemy spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import Unity UI namespace

public class EnemyWaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public float spawnInterval = 1f; // The interval between enemy spawns
    public int maxEnemiesPerWave = 10; // The maximum number of enemies per wave
    public float waveInterval = 5f; // The interval between waves
    public Text waveNumberText; // The UI text object to display the wave number

    private int currentWave = 0; // The current wave number
    private int enemiesSpawned = 0; // The number of enemies spawned in the current wave

    private void Start()
    {
        waveNumberText.text = "Wave " + (currentWave + 1).ToString(); // Set initial wave number in UI text object
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (currentWave < maxEnemiesPerWave)
        {
            if (enemiesSpawned < maxEnemiesPerWave)
            {
                // Spawn an enemy
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                enemiesSpawned++;
            }
            else
            {
                // Wait for the next wave
                yield return new WaitForSeconds(waveInterval);
                currentWave++;
                enemiesSpawned = 0;
                waveNumberText.text = "Wave " + (currentWave + 1).ToString(); // Update wave number in UI text object
            }

            // Wait for the next enemy spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
