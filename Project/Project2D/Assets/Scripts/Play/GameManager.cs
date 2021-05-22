using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                break;

            case TURN.END_TURN:
                break;
        }
    }

    private void PlayerTurn()
    {

    }

    private void GuestTurn()
    {
        int bidCount = 0;

        foreach(var guest in m_guests)
        {
            if(guest.GetComponent<Guest>().Bidding())
            {
                bidCount++;
            }
        }

        m_turn = TURN.CHECK_TURN;
    }

    private void CheckTurn()
    {
        if(m_loopNum == m_nowLoopNum)
        {
            m_turn = TURN.END_TURN;
        }
    }
}
