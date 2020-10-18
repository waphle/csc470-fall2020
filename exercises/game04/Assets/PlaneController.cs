using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
    public Rigidbody rb;

    public GameObject BalloonPrefab;

    public Text scoreText;
    int score = 0;

    float speed = 30;

    float forwardSpeed = 3;

    float pitchSpeed = 120;
    float pitchModSpeedRate = 1f;
    float rollSpeed = 120;

    float zAxis = 2f;
    Vector3 mousePosition; 


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

        if (forwardSpeed <= 0.5f)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }

        float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);
        if (transform.position.y < terrainHeight)
        {
            transform.position = new Vector3(transform.position.x, terrainHeight, transform.position.z);
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = zAxis;
        //If you get an error with the above line, replace it with this:
        //mousePosition = new Vector3(mousePosition.x, mousePosition.y, zAxis);

        Vector3 cameraPosition = transform.position - transform.forward * 12 + Vector3.up * 5;
        Camera.main.transform.position = cameraPosition;
        Vector3 lookAtPos = transform.position + transform.forward * 8;
        Camera.main.transform.LookAt(lookAtPos, Vector3.up);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject balloon = Instantiate(BalloonPrefab, transform.position + transform.forward * 3, Quaternion.identity);
            Rigidbody balloonRB = balloon.GetComponent<Rigidbody>();
            balloonRB.AddForce(transform.forward * 10000);
            Destroy(balloon, 3);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("ufo"))
    //    {
    //        score++;
    //        scoreText.text = score.ToString();
    //        Debug.Log("UFO Shot Down!");

    //    }
    //}
}
