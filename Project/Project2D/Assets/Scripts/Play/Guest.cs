using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest : MonoBehaviour
{
    [SerializeField]
    private int m_targetMoney;

    // 所持金
    [SerializeField]
    private int m_haveMoney;

    // 欲しい度
    private float m_mood = 1.0f;


    // キャッシュしておく
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

        // 入札意欲を算出(仮)
        float bidMotivation = m_mood * voltage.GetVoltageValue();

        // 入札するかどうか
        if (Random.Range(0.0f, 1.0f) < bidMotivation)
        {
            // 入札

            // 入札金額を計算
            bidNum = Random.Range(1, 10) * 10000;

        }
        else
        {
            bidNum = 0;
        }
        

        return bidNum;
    }
}
