using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    [Range(1, 10)] public float spawnRate = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(1/spawnRate);
            float random = Random.Range(0.0f, 1.0f);
            if (random < GameManager.instance.difficulty * 0.1f)
            {
                Instantiate(enemyPrefab[0]);
            }
            else
            {
                Instantiate(enemyPrefab[1]);

            }
        }
    }
}
