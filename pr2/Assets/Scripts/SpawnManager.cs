using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float spawnRangeX = 10.0f;
    private float animalPositionZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimals", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update() { }

    void SpawnRandomAnimals()
    {
        int animalIndex = Random.Range(0, 3);
        float animalPositionX = Random.Range(-spawnRangeX, spawnRangeX);

        Vector3 positionVector = new Vector3(animalPositionX, 0, animalPositionZ);
        GameObject animal = animalPrefabs[animalIndex];

        Instantiate(animal, positionVector, animal.transform.rotation);
    }
}
