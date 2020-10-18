using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufoController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 40 * Time.deltaTime, 0); // Rotate UFO on its y axis 40 degrees per second
    }
}
