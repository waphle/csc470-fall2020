﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(gameObject.name);
        //Debug.Log(gameObject.transform.position.x);


    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        //transform.Translate(0, 0, 0.1f);
        float speed = 0.5f;
        float x = transform.position.x + transform.forward.x * speed;
        float y = transform.position.y + transform.forward.y * speed;
        float z = transform.position.z + transform.forward.z * speed;
        transform.position = new Vector3(x, y, z);
    }
}
