using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voltage : MonoBehaviour
{
    private float m_voltageValue;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
