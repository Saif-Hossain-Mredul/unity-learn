using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    // Start is called before the first frame update
    private float length, width;

    void Start() { 
        Vector3 size = gameObject.GetComponent<BoxCollider>().size;
        length = size.x * 20;
        width = size.z + 3;
    }

    // Update is called once per frame
    void Update()
    {
        MoveRoad();
        DestroyOutOfBound();
    }

    void MoveRoad()
    {
        gameObject.transform.Translate(Vector3.left * 10 * Time.deltaTime);
    }

    void DestroyOutOfBound()
    {
        if (gameObject.transform.position.x < -150)
        {
            Destroy(gameObject);
        }
    }
}
