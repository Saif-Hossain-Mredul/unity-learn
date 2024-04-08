using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectBack : MonoBehaviour
{
    // Start is called before the first frame update
    public float roadSpeed = 50;

    void Start() { }

    // Update is called once per frame
    void Update()
    {
        MoveBack();
    }

    private void MoveBack()
    {
        gameObject.transform.Translate(Vector3.back * roadSpeed * Time.deltaTime);
    }
}