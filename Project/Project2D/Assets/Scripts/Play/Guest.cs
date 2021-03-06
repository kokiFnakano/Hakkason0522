using UnityEngine;
using UnityEngine.UI;

public class Guest : MonoBehaviour
{
    private int m_targetMoney;

    // 所持金
    private static int m_haveMoney;

    // 欲しい度(５段階 : 0〜4)
    private int m_mood = 4;

    // 欲しい度（% ： 0.0〜1.0）
    private float m_wantPer = 1.0f;

    // キャッシュしておく
    Voltage m_voltage;
    Goods m_goods;
    Sprite[] m_faces;

    Image m_face;

    // Start is called before the first frame update
    void Start()
    {
        // キャッシュ
        m_voltage = FindObjectOfType<Voltage>();
        m_goods = FindObjectOfType<Goods>();
        m_faces = Resources.LoadAll<Sprite>("Face");

        // 顔を取得
        m_face = transform.GetChild(0).GetComponent<Image>();


        // 所持金を設定
        m_haveMoney = Random.Range(500000, 10000000);

        UpdateTargetMoney();
    }

    void UpdateTargetMoney()
    {
        // 希望購入金額を更新
        float per = m_goods.GetCurrentMoney() / m_haveMoney;
        if (per < 0.9f)
        {
            m_targetMoney = (int)(m_goods.GetCurrentMoney() * (1.0f + Random.Range(0.1f, 1.0f - per)));
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

        // 欲しい度の更新
        if(m_haveMoney < m_goods.GetCurrentMoney())
        {
            // お金がなかったら入札意欲0に
            m_wantPer = 0.0f;
            m_mood = 0;
        }
        else
        {
            // 最高入札額と希望購入金額から欲しい度を計算
            float want = m_goods.GetCurrentMoney() / m_targetMoney;
            m_wantPer = (2.0f - want) * 0.5f;
            if(m_wantPer < 0.0f)
            {
                m_wantPer = 0.0f;
            }

            m_mood = (int)Mathf.Floor(m_wantPer * 5.0f);
            m_mood %= 5;
        }

        // 顔を変更
        m_face.sprite = m_faces[m_mood];

    }

    public int Bidding()
    {
        int bidNum = 0;

        // 入札意欲を算出(仮)
        float bidMotivation = m_wantPer * (0.5f + m_voltage.GetVoltageValue() * 0.005f);

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
