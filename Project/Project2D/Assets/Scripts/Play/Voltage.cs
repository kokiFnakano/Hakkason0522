using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Voltage : MonoBehaviour
{
    private float m_voltageValue;

    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public float GetVoltageValue()
    {
        return m_voltageValue;
    }

    public void SetVoltageValue(float vv)
    {
        m_voltageValue = vv;
        UpdateUI();
    }

    void UpdateUI()
    {
        if(slider) slider.value = (m_voltageValue + 50) * 0.01f;
    }
}
