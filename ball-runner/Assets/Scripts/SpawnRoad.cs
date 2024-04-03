using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoad : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject roadObject;
    private GameObject[] previousRoadObjects;
    private float length,
        width;

    void Start()
    {
        Vector3 size = roadObject.GetComponent<BoxCollider>().size;
        length = size.x * 20;
        width = size.z + 3;
    }

    // Update is called once per frame
    void Update()
    {
        previousRoadObjects = GameObject.FindGameObjectsWithTag("Road");

        if (previousRoadObjects[0].transform.position.x < 0 && previousRoadObjects.Length < 2)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Vector3 spawnPosition = previousRoadObjects[0].transform.position;
        spawnPosition.x = length - spawnPosition.x - 2;

        Instantiate(roadObject, spawnPosition, previousRoadObjects[0].transform.rotation);
    }
}