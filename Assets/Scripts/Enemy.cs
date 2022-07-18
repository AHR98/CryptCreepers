using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int healthEnemy = 5;
    public float speedEnemy = 1;

    Transform playerPosition;
    public void TakeDamage()
    {
        healthEnemy--;
        if(healthEnemy <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playerPosition = FindObjectOfType<Player>().transform;
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
        transform.position = spawnPoints[randomSpawnPoint].transform.position;
        
    }

    private void Update()
    {
        Vector2 direction = playerPosition.position - transform.position;
        transform.position += (Vector3)direction * Time.deltaTime * speedEnemy ;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().TakeDamage();
        }
    }
}
