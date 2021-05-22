using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest : MonoBehaviour
{
    [SerializeField]
    private int m_targetMoney;

    // ������
    [SerializeField]
    private int m_haveMoney;

    // �~�����x
    private float m_mood = 1.0f;


    // �L���b�V�����Ă���
    Voltage voltage;
    Goods goods;

    // Start is called before the first frame update
    void Start()
    {
        voltage = FindObjectOfType<Voltage>();
        goods = FindObjectOfType<Goods>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMood()
    {
        
    }

    public int Bidding()
    {
        int bidNum = 0;

        // ���D�ӗ~���Z�o(��)
        float bidMotivation = m_mood * voltage.GetVoltageValue();

        // ���D���邩�ǂ���
        if (Random.Range(0.0f, 1.0f) < bidMotivation)
        {
            // ���D

            // ���D���z���v�Z
            bidNum = Random.Range(1, 10) * 10000;

        }
        else
        {
            bidNum = 0;
        }
        

        return bidNum;
    }
}
