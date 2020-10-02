using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    public Renderer rend;

    public Color aliveColor;
    public Color deadColor;

    public int x = -1;
    public int y = -1;

    float goalHeight = 1;
    float growSpeed = 0.8f; // Column grow speed

    private bool _alive = false;
    public bool nextAlive;
    public bool Alive
    {
        get
        {
            return this._alive;
        }
        set
        {
            this._alive = value;

            if (this._alive) {
                rend.material.color = aliveColor;
                goalHeight += 1;
            }
            else {
                rend.material.color = deadColor;
            }
        }
    }


    void Start()
    {
        //rend = gameObject.GetComponent<Renderer>();
        this.Alive = Random.value < 0.1f; // How often the column changes
    }


    void Update()
    {
        // Column grows and shrinks below a threshold.
        float actualGrowSpeed = growSpeed;
        if (!this.Alive) {
            actualGrowSpeed *= -1;
        }

        if (transform.localScale.y < goalHeight) { 
            float newHeight = transform.localScale.y + growSpeed * Time.deltaTime;
            newHeight = Mathf.Clamp(newHeight, 1, 20); // Min and Max height
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 1, transform.localScale.z);
        }
        
    }

}
