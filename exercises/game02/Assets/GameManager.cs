﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject rocketPreFab;
    public GameObject alienPreFab;
    GameObject ground;

    float makeAlienTimer = 0.01f;
    float makeAlienRate = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        ground = GameObject.Find("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        makeAlienTimer -= Time.deltaTime;
        if (makeAlienTimer < 0)
        {
            Vector3 pos = new Vector3(ground.transform.position.x + Random.Range(10, 40)
                                , ground.transform.position.y + 75,
                                  ground.transform.position.z + Random.Range(-55, 35));
            GameObject drop = Instantiate(alienPreFab, pos, Quaternion.identity);


            makeAlienTimer = makeAlienRate;
        }
    }

    public void LaunchRocket()
    {
        Debug.Log("T-minus 3, 2, 1, lift off!");
        Vector3 pos = new Vector3(ground.transform.position.x + Random.Range(-35,35)
                                , ground.transform.position.y,
                                  ground.transform.position.z + Random.Range(-50,50));
        Instantiate(rocketPreFab, pos, Quaternion.identity);
    }
}
