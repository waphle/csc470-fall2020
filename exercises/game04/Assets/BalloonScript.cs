using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BalloonScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ufo"))
        {
            Destroy(other.gameObject);
        }
    }
}
