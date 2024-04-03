using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float spawnPosX = 9.0f;
    public float spawnPosZ = 9.0f;
    public GameObject enemy;
    public GameObject powerup;
    public int enemyCount;
    private int count = 0;

    void Start() { }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            count++;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 enemyPos = new Vector3(
                Random.Range(-spawnPosX, spawnPosX),
                0,
                Random.Range(-spawnPosZ, spawnPosZ)
            );
            Vector3 powerupPos = new Vector3(Random.Range(-spawnPosX, spawnPosX), 0, 6.2f);

            Instantiate(enemy, enemyPos, enemy.transform.rotation);
            Instantiate(powerup, powerupPos, powerup.transform.rotation);
        }
    }
}
