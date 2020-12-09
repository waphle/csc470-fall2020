using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CassetteController : MonoBehaviour
{
    public Text scoreText;
    int score = 0;

    public GameObject CarPrefab;

    void Update()
    {
        transform.Rotate(0, 45 * Time.deltaTime, 0); // Rotate UFO on its y axis clockwise 45 degrees per second
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("car"))
        {
            score++;
            scoreText.text = score.ToString();
            Debug.Log("Cassette Tape Collected!");
        }
    }
}
