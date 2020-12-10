﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public float speed = 0.1f; // Speed of car customization

    int lives = 0;

    void Start()
    {

    }

    private void Update()
    {
        float xDirection = Input.GetAxis("Horizontal"); // Left and Right movements
        float zDirection = Input.GetAxis("Vertical"); // Forward and Backward movements

        Vector3 movementDirection = new Vector3(xDirection, 0.0f, zDirection); // 0.0f in the Y section prevents the 
                                                                               // car from moving vertically up and down

        transform.position += movementDirection * speed;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cassette"))
        {
            Destroy(other.gameObject);
        }

        if (other.CompareTag("obstacle"))
        {
            lives++;
            Debug.Log("You lost your " + lives + " life.");
        }        
    }
}
