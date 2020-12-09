using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public float speed = 0.1f; // Speed of car customization

    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal"); // Left and Right movements
        float zDirection = Input.GetAxis("Vertical"); // Forward and Backward movements

        Vector3 movementDirection = new Vector3(xDirection, 0.0f, zDirection); // 0.0f in the Y section prevents the 
                                                                               // car from moving vertically up and down

        transform.position += movementDirection * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cassette"))
        {
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "LeftWall")
        {
            float pushForce = 500f; // speed of car and wall collision bounce
            Vector3 dir = col.contacts[0].point - transform.position;
            dir = -dir.normalized;
            GetComponent<Rigidbody>().AddForce(dir * pushForce);

            //// how much the character should be knocked back
            //var magnitude = 100000;
            //// calculate force vector
            //var force = transform.position - col.transform.position;
            //// normalize force vector to get direction only and trim magnitude
            //force.Normalize();
            //gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);
        }
    }
}
