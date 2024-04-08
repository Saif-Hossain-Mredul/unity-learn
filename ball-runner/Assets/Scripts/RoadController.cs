using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    // Start is called before the first frame update
    public float roadSpeed = 50;
    private float length,
        width;

    void Start()
    {
        Vector3 size = gameObject.GetComponent<BoxCollider>().size;
        length = size.x * 20;
        width = size.z * 3;
    }

    // Update is called once per frame
    void Update()
    {
        MoveRoad();
    }

    private void MoveRoad()
    {
        gameObject.transform.Translate(Vector3.back * roadSpeed * Time.deltaTime);
    }
}
