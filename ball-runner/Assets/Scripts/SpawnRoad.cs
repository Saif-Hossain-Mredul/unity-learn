using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnRoad : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject roadObject;
    public GameObject block;

    private GameObject[] previousRoadObjects;
    private float length,
        width;

    void Start()
    {
        Vector3 size = roadObject.GetComponent<BoxCollider>().size;
        length = size.z * 20;
        width = size.x * 3;

        Debug.Log(size);
    }

    // Update is called once per frame
    void Update()
    {
        previousRoadObjects = GameObject.FindGameObjectsWithTag("Road");

        if (previousRoadObjects[0].transform.position.z < 100 && previousRoadObjects.Length < 6)
        {
            Spawn(-1);
            Spawn(0);
            Spawn(1);
        }
    }

    private void Spawn(int spawnSide)
    {
        Vector3 spawnPosition = previousRoadObjects.Last().transform.position;
        spawnPosition.z = length + spawnPosition.z - 2;
        spawnPosition.x = spawnSide * 10;

        GameObject road = Instantiate(
            roadObject,
            spawnPosition,
            previousRoadObjects[0].transform.rotation
        );

        gameObject.GetComponent<SpawnObstacle>().SpawnObstacles(spawnSide);
    }
}
