using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest : MonoBehaviour
{
    [SerializeField]
    private int m_targetMoney;

    // Š‹à
    [SerializeField]
    private int m_haveMoney;

    // —~‚µ‚¢“x
    private float m_mood = 1.0f;


    // ƒLƒƒƒbƒVƒ…‚µ‚Ä‚¨‚­
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

        // “üDˆÓ—~‚ğZo(‰¼)
        float bidMotivation = m_mood * voltage.GetVoltageValue();

        // “üD‚·‚é‚©‚Ç‚¤‚©
        if (Random.Range(0.0f, 1.0f) < bidMotivation)
        {
            // “üD

            // “üD‹àŠz‚ğŒvZ
            bidNum = Random.Range(1, 10) * 10000;

        }
        else
        {
            bidNum = 0;
        }
        

        return bidNum;
    }
}
