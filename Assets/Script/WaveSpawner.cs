using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Kailangan para sa Win/Restart
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [Header("Settings")]
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    public float timeBetweenWaves = 3f;
    public int totalWaves = 10;

    [Header("UI Settings")]
    public TextMeshProUGUI waveText; // <--- Dito natin ilalagay yung Text object

    [Header("Status")]
    public int currentWave = 0;
    public float waveCountdown;
    public SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
        currentWave = 0;
        UpdateWaveText(); // Update agad sa simula
    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                if (currentWave >= totalWaves)
                {
                    Debug.Log("PANALO KA NA!");
                    waveText.text = "VICTORY!"; // Palitan ang text pag nanalo
                    enabled = false;
                }
                else
                {
                    StartCoroutine(SpawnWave());
                }
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave()
    {
        state = SpawnState.SPAWNING;
        currentWave++; // Next wave

        UpdateWaveText(); // <--- Update ang text sa screen (e.g., Wave: 1)

        int enemiesToSpawn = currentWave * 2;

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform sp = spawnPoints[randomIndex];
        Instantiate(enemyPrefab, sp.position, sp.rotation);
    }

    bool EnemyIsAlive()
    {
        waveCountdown = timeBetweenWaves;
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            return false;
        }
        return true;
    }

    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;
    }

    // Function para i-update ang UI Text
    void UpdateWaveText()
    {
        if (waveText != null)
        {
            waveText.text = "Wave: " + currentWave;
        }
    }
}