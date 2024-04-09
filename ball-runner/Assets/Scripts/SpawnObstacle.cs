using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject[] obstacles;

    private float roadStartPos;
    private int length;

    // Start is called before the first frame update
    void Start()
    {
        roadStartPos = transform.position.z + 85;
        length = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (length > 200)
            length = 0;
    }

    public void SpawnObstacles(int spawnSide)
    {
        while (200 - length > 40)
        {
            GameObject obstacle = obstacles[Random.Range(0, 2)];

            int distance = Random.Range(40, 45);

            length += distance;
            Vector3 spawnPos;

            if (obstacle.CompareTag("Bar"))
            {
                spawnPos = new Vector3(spawnSide * 10, Random.Range(2, 6), length + roadStartPos);

                Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
            }
            else if (obstacle.CompareTag("Block"))
            {
                spawnPos = new Vector3(
                    spawnSide * 10,
                    obstacle.transform.position.y,
                    length + roadStartPos
                );
                Instantiate(obstacle, spawnPos, obstacle.transform.rotation);

                length += 40;
            }
        }

        length = 0;
    }
}
