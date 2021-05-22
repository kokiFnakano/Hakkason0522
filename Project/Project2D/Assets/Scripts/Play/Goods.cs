using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goods : MonoBehaviour
{
    [SerializeField]
    private int m_startMoney;

    [SerializeField]
    Text m_moneyText = null;

    private int m_currentMoney;

    // Start is called before the first frame update
    void Start()
    {
        m_currentMoney = m_startMoney;
    }

    // Update is called once per frame
    void Update()
    {
        m_moneyText.text = m_currentMoney.ToString();
    }


    public int GetStartMoney()
    {
        return m_startMoney;
    }

    public int GetCurrentMoney()
    {
        return m_currentMoney;
    }


    public void SetCurrentMoney(int currentMoney)
    {
        m_currentMoney = currentMoney;
    }
}
