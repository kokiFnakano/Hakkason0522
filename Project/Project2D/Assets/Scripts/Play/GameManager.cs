using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //ターンステータス
    public enum TURN
    {
        PLAYER_TURN,
        GUEST_TURN,
        CHECK_TURN,
        END_TURN,
    }
    private TURN m_turn;

    //ターンLoop回数
    [SerializeField]
    private int m_loopNum = 5;
    private int m_nowLoopNum = 0;

    //グッズ
    [SerializeField]
    private GameObject m_goods = null;
    private int m_beforeMoney = 0;

    //ゲスト
    [SerializeField]
    private List<GameObject> m_guests = new List<GameObject>();
    //ゲストの入札数
    private int m_bidCount = 0;
    //ゲストターン時間
    [SerializeField]
    private float m_guestTurnSecond = 3;
    //解答時間カウント用
    private float m_guestTurnSecondCount = 0;

    //プレイヤー
    [SerializeField]
    private GameObject m_player = null;
    //解答時間
    [SerializeField]
    private float m_playerTurnSecond = 3;
    //解答時間カウント用
    private float m_playerTurnSecondCount = 0;


    //最後にbidしたのがプレイヤー
    private bool m_lastBidPlayer = true;


    //次のシーン設定
    [SerializeField]
    private int m_nextSceneNumber = 0;


    //Voltage
    [SerializeField]
    GameObject m_voltage = null;

    // Start is called before the first frame update
    void Start()
    {
        m_turn = TURN.PLAYER_TURN;
    }

    // Update is called once per frame
    void Update()
    {
        TurnLoop();
    }


    private void TurnLoop()
    {
        switch (m_turn)
        {
            case TURN.PLAYER_TURN:
                PlayerTurn();
                break;

            case TURN.GUEST_TURN:
                GuestTurn();
                break;

            case TURN.CHECK_TURN:
                CheckTurn();
                break;

            case TURN.END_TURN:
                EndTurn();
                break;
        }
    }

    private void PlayerTurn()
    {
        if(m_playerTurnSecond < m_playerTurnSecondCount)
        {
            Player player = m_player.GetComponent<Player>();
            //プレイヤーのレイズ額をグッズのカレントに足す
            Goods goods = m_goods.GetComponent<Goods>();
            goods.SetCurrentMoney(goods.GetCurrentMoney() + player.GetRaiseValue());

            VoltageUpdate(5);

            m_beforeMoney = goods.GetCurrentMoney();

            player.ResetButtons();

            m_turn = TURN.GUEST_TURN;

            //プレイヤーのレイズ額が0より大きかったら
            m_lastBidPlayer = true;
            //else
            m_lastBidPlayer = false;

            m_playerTurnSecondCount = 0;
        }

        m_playerTurnSecondCount+=Time.deltaTime;
    }

    private void GuestTurn()
    {
        if (m_guestTurnSecond == 0)
        {
            int bidCount = 0;
            int maxBidNum = 0;

            foreach (var guest in m_guests)
            {
                int bidNum = guest.GetComponent<Guest>().Bidding();
                if (0 < bidNum)
                {
                    bidCount++;
                    m_lastBidPlayer = false;

                    if (maxBidNum < bidNum)
                    {
                        maxBidNum = bidNum;
                    }
                }
            }

            //グッズのカレントに足す
            var goods = m_goods.GetComponent<Goods>();
            goods.SetCurrentMoney(goods.GetCurrentMoney() + maxBidNum);


            VoltageUpdate(bidCount);


            m_beforeMoney = goods.GetCurrentMoney();
            m_bidCount = bidCount;
        }

        m_guestTurnSecondCount += Time.deltaTime;

        if (m_guestTurnSecond < m_guestTurnSecondCount)
        {
            m_turn = TURN.CHECK_TURN;
            m_guestTurnSecondCount = 0;
        }
    }

    private void CheckTurn()
    {
        //Loop上限に行ったとき
        if (m_loopNum == m_nowLoopNum)
        {
            m_turn = TURN.END_TURN;
        }

        //ベットした客がいなかったとき
        if(m_bidCount == 0)
        {
            m_turn = TURN.END_TURN;
        }

        m_turn = TURN.PLAYER_TURN;
    }

    private void EndTurn()
    {
        //プレイヤーが最後だったらグッズのカレント額引く
        //客が最後だったらグッズのカレント額足す
        if(m_lastBidPlayer)
        {
            PlayerPrefs.SetInt("ResultScore", PlayerPrefs.GetInt("ResultScore") - m_goods.GetComponent<Goods>().GetCurrentMoney());
        }
        else
        {
            PlayerPrefs.SetInt("ResultScore", PlayerPrefs.GetInt("ResultScore") + m_goods.GetComponent<Goods>().GetCurrentMoney());
        }

        SceneManager.LoadScene(m_nextSceneNumber);
    }


    void VoltageUpdate(int raizeNum)
    {
        Goods goods = m_goods.GetComponent<Goods>();
        Voltage voltage = m_voltage.GetComponent<Voltage>();

        if(raizeNum >= 4)
        {
            voltage.SetVoltageValue(voltage.GetVoltageValue() + raizeNum * ((goods.GetCurrentMoney() - m_beforeMoney) / 20000));
        }
        else
        {
            voltage.SetVoltageValue(voltage.GetVoltageValue() - (10 - raizeNum));
        }
    }
}
