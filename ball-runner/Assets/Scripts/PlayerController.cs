using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 700;
    public float limitX = 8;

    void Start() { }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.RotateAround(
            transform.position,
            Vector3.right,
            rotationSpeed * Time.deltaTime
        );

        Vector3 playerPosition = transform.position;

        if (Input.GetKeyDown(KeyCode.RightArrow) && playerPosition.x < limitX)
        {
            gameObject.transform.Translate(Vector3.right * limitX);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && playerPosition.x > -limitX)
        {
            gameObject.transform.Translate(Vector3.left * limitX);
        }
    }
}
