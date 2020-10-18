using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ufoController : MonoBehaviour
{
    public Text scoreText;
    int score = 0;

    public GameObject BalloonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 45 * Time.deltaTime, 0); // Rotate UFO on its y axis 45 degrees per second
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            score++;
            scoreText.text = score.ToString();
            Debug.Log("UFO Shot Down!");
        }
    }
}
