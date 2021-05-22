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

    // �~�����x(�T�i�K : 0�`4)
    private int m_mood = 4;

    // �~�����x�i% �F 0.0�`1.0�j
    private float m_wantPer = 1.0f;

    // �L���b�V�����Ă���
    Voltage m_voltage;
    Goods m_goods;

    // Start is called before the first frame update
    void Start()
    {
        m_voltage = FindObjectOfType<Voltage>();
        m_goods = FindObjectOfType<Goods>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMood()
    {

        // �~�����x�̍X�V
        if(m_haveMoney < m_goods.GetCurrentMoney())
        {
            // �������Ȃ���������D�ӗ~0��
            m_wantPer = 0.0f;
            m_mood = 0;
        }
        else
        {
            // �ō����D�z�Ɗ�]�w�����z����~�����x���v�Z
            float want = m_goods.GetCurrentMoney() / m_targetMoney;
            m_wantPer = (2.0f - want) * 0.5f;
            if(m_wantPer < 0.0f)
            {
                m_wantPer = 0.0f;
            }

            m_mood = (int)Mathf.Floor(m_wantPer * 5.0f);
            m_mood %= 5;
        }

    }

    public int Bidding()
    {
        int bidNum = 0;

        // ���D�ӗ~���Z�o(��)
        float bidMotivation = m_mood * m_voltage.GetVoltageValue();

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
