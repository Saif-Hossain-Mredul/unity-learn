using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectBack : MonoBehaviour
{
    // Start is called before the first frame update
    private float roadSpeed = 20;
    private bool gameOver;

    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBack();
    }

    private void MoveBack()
    {
        if (!gameOver)
        {
            gameObject.transform.Translate(Vector3.back * roadSpeed * Time.deltaTime);
        }
    }

    public void StopMovement()
    {
        gameOver = true;
    }
}
