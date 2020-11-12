using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterScript : MonoBehaviour

{
    public string label;
    public Color meterColor;
    public Text labelText;
    public Image meterForeground;

    // Start is called before the first frame update
    void Start()
    {
        labelText.text = label;
        meterForeground.color = meterColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMeter(float val)
    {
        meterForeground.fillAmount = val;
    }
}
