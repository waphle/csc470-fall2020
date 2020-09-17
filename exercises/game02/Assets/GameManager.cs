using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject rocketPreFab;
    GameObject ground;

    // Start is called before the first frame update
    void Start()
    {
        ground = GameObject.Find("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchRocket()
    {
        Debug.Log("T-minus 3, 2, 1, lift off!");
        Vector3 pos = new Vector3(ground.transform.position.x + Random.Range(-20,20)
                                , ground.transform.position.y + 20,
                                  ground.transform.position.z + Random.Range(-20,20));
        Instantiate(rocketPreFab, pos, Quaternion.identity);
    }
}
