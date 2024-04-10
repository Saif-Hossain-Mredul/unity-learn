using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 700;
    public float limitX = 8;
    public TextMeshProUGUI gameOverText;
    public MoveObjectBack moveBack;

    private Rigidbody playerRb;
    private BoxCollider playerCollider;
    private float forceImpulseValue = 10;
    private bool isOnRoad;
    private bool gameOver;
    private bool moving = false;
    private Vector3 endPos;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<BoxCollider>();
        isOnRoad = true;
        gameOver = false;
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            RotateThePlayerBall();
            MovePlayerHorizontally();
            JumpPlayer();
        }
        GameOverShow();
    }

    private void GameOverShow()
    {
        if (gameOver)
        {
            gameOverText.gameObject.SetActive(true);
            moveBack.StopMovement();
        }
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
            endPos = playerPosition;
            endPos.x += (1 * limitX);
            moving = true;

            // gameObject.transform.Translate(Vector3.right * limitX);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && playerPosition.x > -limitX && isOnRoad)
        {
            endPos = playerPosition;
            endPos.x -= (1 * limitX);
            moving = true;

            // gameObject.transform.Translate(Vector3.left * limitX);
        }

        if (moving)
        {
            transform.position = Vector3.MoveTowards(playerPosition, endPos, 20 * Time.deltaTime);

            if (transform.position == endPos)
            {
                moving = false;
            }
        }
    }

    void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnRoad)
        {
            playerRb.AddForce(Vector3.up * forceImpulseValue, ForceMode.Impulse);
        }
    }

    public bool GameOver
    {
        get { return gameOver; }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Road" || other.gameObject.tag == "Block")
        {
            isOnRoad = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Road" || other.gameObject.tag == "Block")
        {
            isOnRoad = true;
        }

        if (other.gameObject.CompareTag("Block"))
        {
            Vector3 contactPoint = other.GetContact(0).point;

            if (contactPoint.y < 3)
            {
                Debug.Log("Collided on the front");
                gameOver = true;
            }
        }

        if (other.gameObject.CompareTag("Bar"))
        {
            Debug.Log("Collided with bar");
            gameOver = true;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Road" || other.gameObject.tag == "Block")
        {
            isOnRoad = true;
        }
    }
}
