using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 700;
    public float limitX = 8;

    private Rigidbody playerRb;
    private BoxCollider playerCollider;
    private float forceImpulseValue = 12;
    private bool isOnRoad;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<BoxCollider>();
        isOnRoad = true;
    }

    // Update is called once per frame
    void Update()
    {
        RotateThePlayerBall();
        MovePlayerHorizontally();
        JumpPlayer();
    }

    void RotateThePlayerBall()
    {
        gameObject.transform.RotateAround(
            transform.position,
            Vector3.right,
            rotationSpeed * Time.deltaTime
        );
    }

    void MovePlayerHorizontally()
    {
        Vector3 playerPosition = transform.position;

        if (Input.GetKeyDown(KeyCode.RightArrow) && playerPosition.x < limitX && isOnRoad)
        {
            gameObject.transform.Translate(Vector3.right * limitX);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && playerPosition.x > -limitX && isOnRoad)
        {
            gameObject.transform.Translate(Vector3.left * limitX);
        }
    }

    void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnRoad)
        {
            playerRb.AddForce(Vector3.up * forceImpulseValue, ForceMode.Impulse);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Road")
        {
            isOnRoad = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Road")
        {
            isOnRoad = true;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Road")
        {
            isOnRoad = true;
        }
    }
}
