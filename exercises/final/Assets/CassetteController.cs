using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CassetteController : MonoBehaviour
{
    public GameObject CarPrefab;

    public AudioSource playSound;

    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0); // Rotate on its y axis clockwise 90 degrees per second
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("car"))
        {
            playSound.Play();
            Debug.Log("Cassette Tape Collected!");
        }
    }
}
