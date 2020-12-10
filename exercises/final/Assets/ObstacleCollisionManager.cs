using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollisionManager : MonoBehaviour
{
    public Color redcolor;
    public Color bluecolor;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("car"))
        {
            Debug.Log("Collision");
            transform.GetComponent<Renderer>().material.color = redcolor;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
