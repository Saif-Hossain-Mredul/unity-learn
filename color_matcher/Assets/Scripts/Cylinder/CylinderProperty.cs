using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderProperty : MonoBehaviour
{
    // Start is called before the first frame update
    public Material[] cylinderMaterials;

    void Start()
    {
        gameObject.GetComponent<Renderer>().material = cylinderMaterials[
            Random.Range(0, cylinderMaterials.Length)
        ];
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(1, Random.Range(5, 12), 1);
    }
}
