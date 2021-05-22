using UnityEngine;
using UnityEngine.UI;

public class Guest : MonoBehaviour
{
    [SerializeField]
    private int m_targetMoney;

    // ������
    [SerializeField]
    private static int m_haveMoney;

    // �~�����x(�T�i�K : 0�`4)
    private int m_mood = 4;

    // �~�����x�i% �F 0.0�`1.0�j
    private float m_wantPer = 1.0f;

    // �L���b�V�����Ă���
    Voltage m_voltage;
    Goods m_goods;
    Sprite[] m_faces;

    Image m_face;

    // Start is called before the first frame update
    void Start()
    {
        // �L���b�V��
        m_voltage = FindObjectOfType<Voltage>();
        m_goods = FindObjectOfType<Goods>();
        m_faces = Resources.LoadAll<Sprite>("Face");

        // ����擾
        m_face = transform.GetChild(0).GetComponent<Image>();

        UpdateTargetMoney();
    }

    void UpdateTargetMoney()
    {
        // ��]�w�����z���X�V
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

        // ���ύX
        m_face.sprite = m_faces[m_mood];

    }

    public int Bidding()
    {
        int bidNum = 0;

        // ���D�ӗ~���Z�o(��)
        float bidMotivation = m_wantPer * (m_voltage.GetVoltageValue() * 0.005f);

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
