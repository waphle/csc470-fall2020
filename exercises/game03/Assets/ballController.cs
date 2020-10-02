using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    public float speed = 20f; // Speed of ball
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w")) { // Forward
            pos.z += speed * Time.deltaTime;
        }

        if (Input.GetKey("s")) { // Backwards
            pos.z -= speed * Time.deltaTime;
        }

        if (Input.GetKey("d")) { // Right
            pos.x += speed * Time.deltaTime;
        }

        if (Input.GetKey("a")) { // Left
            pos.x -= speed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
