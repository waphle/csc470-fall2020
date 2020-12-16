using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 6f;
        float x = transform.position.x + Time.deltaTime * transform.forward.x * speed;
        float y = transform.position.y + Time.deltaTime * transform.forward.y * speed;
        float z = transform.position.z + Time.deltaTime * transform.forward.z * speed;
        transform.position = new Vector3(-x, -y, z);
    }
}
