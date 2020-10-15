using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public Rigidbody rb;

    float speed = 20;

    float forwardSpeed = 1;

    float pitchSpeed = 80;
    float pitchModSpeedRate = 0.5f;
    float rollSpeed = 80;


    void Start()
    {
        
    }

    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        float xRot = vAxis * pitchSpeed * Time.deltaTime;
        float yRot = hAxis * rollSpeed / 4 * Time.deltaTime;
        float zRot = -hAxis * rollSpeed * Time.deltaTime;
        transform.Rotate(xRot, yRot, zRot, Space.Self);

        forwardSpeed += -transform.forward.y * pitchModSpeedRate * Time.deltaTime;
        forwardSpeed = Mathf.Clamp(forwardSpeed, 0, speed * 2);

        transform.Translate(transform.forward * speed * forwardSpeed * Time.deltaTime, Space.World);

        //if (forwardSpeed <= 0)
        //{
        //    transform.Translate(Vector3.down * speed/40 * Time.deltaTime, Space.World);
        //}

        if (forwardSpeed <= 0.3f)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }

        float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);
        if (transform.position.y < terrainHeight)
        {
            transform.position = new Vector3(transform.position.x, terrainHeight, transform.position.z);
        }

        Vector3 cameraPosition = transform.position - transform.forward * 12 + Vector3.up * 5;
        Camera.main.transform.position = cameraPosition;
        Vector3 lookAtPos = transform.position + transform.forward * 8;
        Camera.main.transform.LookAt(lookAtPos, Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ring"))
        {
            Debug.Log("Ring Collected!");
        }
    }
}
