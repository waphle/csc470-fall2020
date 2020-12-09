using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public float speed = 0.1f; // Speed customization

    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal"); // Left and Right movements
        float zDirection = Input.GetAxis("Vertical"); // Forward and Backward movements

        Vector3 movementDirection = new Vector3(xDirection, 0.0f, zDirection); // 0.0f in the Y section prevents the 
                                                                               // car from moving vertically up and down

        transform.position += movementDirection * speed;
    }
}
