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

    public void SpawnBars()
    {
        for (int i = 0; i < 5; i++)
        {
            int distance = Random.Range(40, 45);

            length += distance;

            Vector3 spawnPos = new Vector3(
                Random.Range(-1, 2) * 10,
                Random.Range(2, 6),
                length + roadStartPos
            );

            Instantiate(obstacles[1], spawnPos, obstacles[1].transform.rotation);
        }
    }
}
