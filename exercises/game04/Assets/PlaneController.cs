using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    float speed = 15;

    float forwardSpeed = 1;

    float pitchSpeed = 80;
    float rollSpeed = 80;


    void Start()
    {
        
    }

    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        transform.Rotate(vAxis * pitchSpeed * Time.deltaTime, hAxis * rollSpeed * Time.deltaTime, 0, Space.Self);

        forwardSpeed += -transform.forward.y * 10 * Time.deltaTime;

        forwardSpeed = Mathf.Clamp(forwardSpeed, 0, speed * 2);

        transform.Translate(transform.forward * speed * forwardSpeed * Time.deltaTime, Space.World);

        if (forwardSpeed <= 0)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);
        if (transform.position.y < terrainHeight)
        {
            transform.position = new Vector3(transform.position.x, terrainHeight, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ring"))
        {
            Debug.Log("Ring Collected!");
        }
    }
}
