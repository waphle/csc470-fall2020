﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hotairballoon"))
        {
            Destroy(other.gameObject);
        }


        if (other.CompareTag("ufo"))
        {
            Destroy(other.gameObject);
        }

    }
}
