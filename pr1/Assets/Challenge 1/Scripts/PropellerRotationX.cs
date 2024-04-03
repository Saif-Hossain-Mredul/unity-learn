using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerRotationX : MonoBehaviour
{
    private float rotationSpeed = 1000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // rotates the propeller
        transform.Rotate(Vector3.forward * Time.deltaTime* rotationSpeed );
    }
}
