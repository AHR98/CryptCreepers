using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject checkPointPrefab;
    [SerializeField] GameObject[] powerUpPrefab;
    [SerializeField] int checkPointSpawnDelay = 10;
    [SerializeField] int powerUpSpawnDelay = 12;
    [SerializeField] float spawnRadius = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnCheckPointRoutine());
        StartCoroutine(spawnPowerUpRoutine());
    }
    /// <summary>
    /// Inicializa en un radio de 5 los corazoncitos
    /// </summary>
    /// <returns></returns>
    IEnumerator spawnCheckPointRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(checkPointSpawnDelay);
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;

            Instantiate(checkPointPrefab, randomPosition, Quaternion.identity);
        }
       
    }
    IEnumerator spawnPowerUpRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(powerUpSpawnDelay);
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
            int randomPowerUp = Random.Range(0, powerUpPrefab.Length);
            Instantiate(powerUpPrefab[randomPowerUp], randomPosition, Quaternion.identity);
        }

    }
}
