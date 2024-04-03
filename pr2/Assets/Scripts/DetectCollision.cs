using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public int lives;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(lives);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (lives == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            lives--;
        }
    }
}
