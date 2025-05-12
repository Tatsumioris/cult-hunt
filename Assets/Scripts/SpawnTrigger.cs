using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    private bool hasSpawned = false;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasSpawned && other.CompareTag("Player"))
        {
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            hasSpawned = true; //Evite les multiples appartitions
            Debug.Log("apparition");
        }
    }
}
