using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollisionManager : MonoBehaviour
{
    public Color defaultColor;
    public Color hitColor;

    public AudioSource playSound;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("car"))
        {
            playSound.Play();
            transform.GetComponent<Renderer>().material.color = hitColor;

            Debug.Log("Collision Detected");
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
