using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Material[] sphereMaterials;

    private float limitX = 4;
    private Vector3 endPos;
    private bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject firstCylinder = GameObject.FindGameObjectsWithTag("Cylinder")[0];
        AddRandomMaterial();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayerHorizontally();
    }

    void MovePlayerHorizontally()
    {
        Vector3 playerPosition = transform.position;

        if (Input.GetKey(KeyCode.RightArrow) && playerPosition.x < limitX)
        {
            endPos = playerPosition;
            endPos.x += (1);
            moving = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && playerPosition.x > -limitX)
        {
            endPos = playerPosition;
            endPos.x -= (1);
            moving = true;
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

    private void OnCollisionEnter(Collision other)
    {
        Material otherMaterial = other.gameObject.GetComponent<Renderer>().material;
        Material sphereMaterial = gameObject.GetComponent<Renderer>().material;

        if (other.gameObject.CompareTag("Cylinder") && otherMaterial.color == sphereMaterial.color)
        {
            Debug.Log("collided with same material");
            Destroy(other.gameObject);

            AddRandomMaterial();
        }
    }

    private void AddRandomMaterial()
    {
        gameObject.GetComponent<Renderer>().material = sphereMaterials[
            Random.Range(0, sphereMaterials.Length)
        ];
    }
}
