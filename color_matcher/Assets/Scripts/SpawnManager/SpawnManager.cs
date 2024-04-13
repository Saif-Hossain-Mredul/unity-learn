using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cylinder;
    public GameObject player;

    Vector3 lastCylinderPosition,
        newCylinderPosition,
        cylinderScale;

    void Start() { 
        Instantiate(player, new Vector3(-4, 1, 0), player.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] cylinders = GameObject.FindGameObjectsWithTag("Cylinder");
        GameObject lastCylinder = cylinders.Last();

        if (lastCylinder.transform.position.z < 16 && cylinders.Length < 4)
        {
            lastCylinderPosition = lastCylinder.transform.position;
            float lastCylinderLength = lastCylinder.transform.localScale.y * 2;

            int newCylinderLength = Random.Range(5, 10);

            newCylinderPosition =
                lastCylinderPosition
                + new Vector3(0, 0, lastCylinderLength / 2)
                + new Vector3(0, 0, newCylinderLength);

            cylinderScale = new Vector3(1, newCylinderLength, 1);
            cylinder.transform.localScale = cylinderScale;

            Instantiate(cylinder, newCylinderPosition, cylinder.transform.rotation);
        }
    }
}
