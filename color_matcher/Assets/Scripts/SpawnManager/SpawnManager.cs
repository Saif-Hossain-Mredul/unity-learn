using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cylinder;

    Vector3 lastCylinderPosition,
        newCylinderPosition,
        cylinderScale;

    void Start() { }

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

            Debug.Log(
                lastCylinder.transform.localScale.y
                    + "   "
                    + lastCylinderPosition
                    + " "
                    + newCylinderPosition
                    + "   "
                    + cylinder.transform.localScale.y
            );

            cylinderScale = new Vector3(1, newCylinderLength, 1);
            cylinder.transform.localScale = cylinderScale;

            Instantiate(cylinder, newCylinderPosition, cylinder.transform.rotation);
        }
    }
}
