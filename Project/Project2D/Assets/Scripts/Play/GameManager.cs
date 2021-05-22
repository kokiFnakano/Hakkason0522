using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum TURN
    {
        PLAYER_TURN,
        GUEST_TURN,
        CHECK_TURN,
        END_TURN,
    }
    private TURN m_turn;
    [SerializeField]
    private int m_loopNum = 5;
    private int m_nowLoopNum = 0;

    [SerializeField]
    private GameObject m_goods;

    [SerializeField]
    private List<GameObject> m_guests = new List<GameObject>();
    private int m_bidCount = 0;

    //最後にbidしたのがプレイヤー
    private bool m_lastBidPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        
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
        m_lastBidPlayer = true;
    }

    private void GuestTurn()
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

                if(maxBidNum < bidNum)
                {
                    maxBidNum = bidNum;
                }
            }
        }

        m_bidCount = bidCount;
        m_turn = TURN.CHECK_TURN;
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
    }

    private void EndTurn()
    {
        if(m_lastBidPlayer)
        {
            PlayerPrefs.SetInt("ResultScore", PlayerPrefs.GetInt("Result") + m_goods.GetComponent<Goods>().GetCurrentMoney());
        }
        else
        {
            PlayerPrefs.SetInt("ResultScore", PlayerPrefs.GetInt("Result") - m_goods.GetComponent<Goods>().GetCurrentMoney());
        }

        SceneManager.LoadScene("Result");
    }
}
