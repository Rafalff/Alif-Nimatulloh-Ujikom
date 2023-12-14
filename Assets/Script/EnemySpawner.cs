using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] animalSpawn;
    [SerializeField] private Transform[] spawnTransform;

    [SerializeField] private float interval;
    private float startInterval;
    private void Start() {
        
    }
    private void Update() {
        startInterval += Time.deltaTime;
            if(startInterval >= interval) {
            SpawnAnimal();
            startInterval = 0;
        }
    }

    private void SpawnAnimal() {
        int location = Random.Range(0, spawnTransform.Length);
        int animalToSpawn = Random.Range(0,animalSpawn.Length);
        GameObject animalSpawned = Instantiate(animalSpawn[animalToSpawn], spawnTransform[location].transform.position, Quaternion.LookRotation(Vector3.back));
    }

}
