using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    public float limitY = 1.0f;
    public int point;
    public ParticleSystem explosionParticle;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        Rigidbody randomObjectRigidbody = GetComponent<Rigidbody>();
        randomObjectRigidbody.AddForce(Vector3.up * Random.Range(8, 13), ForceMode.Impulse);
        randomObjectRigidbody.AddTorque(
            Random.Range(-10, 10),
            Random.Range(-10, 10),
            Random.Range(-10, 10),
            ForceMode.Impulse
        );
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -limitY)
        {
            Destroy(gameObject);

            if (!gameObject.CompareTag("badObject"))
            {
                gameManager.GameOver();
            }
        }
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(
                explosionParticle,
                transform.position,
                explosionParticle.transform.rotation
            );
            gameManager.UpdateScore(point);
        }
    }
}
