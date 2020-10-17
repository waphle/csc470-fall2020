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

    float speed = 20;

    float forwardSpeed = 3;

    float pitchSpeed = 120;
    float pitchModSpeedRate = 2f;
    float rollSpeed = 120;


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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject balloon = Instantiate(BalloonPrefab, transform.position + transform.forward * 3, Quaternion.identity);
            Rigidbody balloonRB = balloon.GetComponent<Rigidbody>();
            balloonRB.AddForce(transform.forward * 4000);
            Destroy(balloon, 5);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ring"))
        {
            score++;
            scoreText.text = score.ToString();
            Debug.Log("Ring Collected!");
        }
    }
}
