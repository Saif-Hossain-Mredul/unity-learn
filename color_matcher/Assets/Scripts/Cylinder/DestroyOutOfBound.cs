using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    // Start is called before the first frame update
    private float limitZ = 15;

    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -limitZ)
        {
            Destroy(gameObject);
        }
    }
}
