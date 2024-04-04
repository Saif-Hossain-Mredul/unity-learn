using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.RotateAround(transform.position, Vector3.right, 400 * Time.deltaTime);

        Vector3 playerPosition = transform.position;

        if (Input.GetKeyDown(KeyCode.RightArrow) && playerPosition.x > -8)
        {
            playerPosition.x += 8;
            transform.position = playerPosition;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && playerPosition.x < 8)
        {
            playerPosition.x -= 8;
            transform.position = playerPosition;
        }

        Debug.Log(playerPosition);
    }
}
