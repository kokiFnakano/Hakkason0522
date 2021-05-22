using UnityEngine;
using UnityEngine.UI;

public class Guest : MonoBehaviour
{
    [SerializeField]
    private int m_targetMoney;

    // Š‹à
    [SerializeField]
    private static int m_haveMoney;

    // —~‚µ‚¢“x(‚T’iŠK : 0`4)
    private int m_mood = 4;

    // —~‚µ‚¢“xi% F 0.0`1.0j
    private float m_wantPer = 1.0f;

    // ƒLƒƒƒbƒVƒ…‚µ‚Ä‚¨‚­
    Voltage m_voltage;
    Goods m_goods;
    Sprite[] m_faces;

    Image m_face;

    // Start is called before the first frame update
    void Start()
    {
        // ƒLƒƒƒbƒVƒ…
        m_voltage = FindObjectOfType<Voltage>();
        m_goods = FindObjectOfType<Goods>();
        m_faces = Resources.LoadAll<Sprite>("Face");

        // Šç‚ğæ“¾
        m_face = transform.GetChild(0).GetComponent<Image>();

        UpdateTargetMoney();
    }

    void UpdateTargetMoney()
    {
        // Šó–]w“ü‹àŠz‚ğXV
        float per = 1.0f - (m_goods.GetCurrentMoney() / m_haveMoney);
        if (per < 0.9f)
        {
            m_targetMoney = (int)(m_goods.GetCurrentMoney() * (1.0f + Random.Range(0.1f, 0.1f + 1.0f - per)));
        }
        else
        {
            m_targetMoney = m_haveMoney;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMood()
    {

        // —~‚µ‚¢“x‚ÌXV
        if(m_haveMoney < m_goods.GetCurrentMoney())
        {
            // ‚¨‹à‚ª‚È‚©‚Á‚½‚ç“üDˆÓ—~0‚É
            m_wantPer = 0.0f;
            m_mood = 0;
        }
        else
        {
            // Å‚“üDŠz‚ÆŠó–]w“ü‹àŠz‚©‚ç—~‚µ‚¢“x‚ğŒvZ
            float want = m_goods.GetCurrentMoney() / m_targetMoney;
            m_wantPer = (2.0f - want) * 0.5f;
            if(m_wantPer < 0.0f)
            {
                m_wantPer = 0.0f;
            }

            m_mood = (int)Mathf.Floor(m_wantPer * 5.0f);
            m_mood %= 5;
        }

        // Šç‚ğ•ÏX
        m_face.sprite = m_faces[m_mood];

    }

    public int Bidding()
    {
        int bidNum = 0;

        // “üDˆÓ—~‚ğZo(‰¼)
        float bidMotivation = m_wantPer * (m_voltage.GetVoltageValue() * 0.005f);

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
