using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //�^�[���X�e�[�^�X
    public enum TURN
    {
        PLAYER_TURN,
        GUEST_TURN,
        CHECK_TURN,
        END_TURN,
    }
    private TURN m_turn;

    //�^�[��Loop��
    [SerializeField]
    private int m_loopNum = 5;
    private int m_nowLoopNum = 0;

    //�O�b�Y
    [SerializeField]
    private GameObject m_goods = null;

    //�Q�X�g
    [SerializeField]
    private List<GameObject> m_guests = new List<GameObject>();
    //�Q�X�g�̓��D��
    private int m_bidCount = 0;

    //�v���C���[
    [SerializeField]
    private GameObject m_player = null;
    //�𓚎���
    [SerializeField]
    private float m_playerTurnFream = 3;
    //�𓚎��ԃJ�E���g�p
    private float m_playerTurnFreamCount = 0;


    //�Ō��bid�����̂��v���C���[
    private bool m_lastBidPlayer = true;


    //���̃V�[���ݒ�
    [SerializeField]
    private int m_nextSceneNumber = 0;

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
        if(m_playerTurnFream < m_playerTurnFreamCount)
        {
            //�v���C���[�̃��C�Y�z���O�b�Y�̃J�����g�ɑ���

            m_turn = TURN.GUEST_TURN;

            //�v���C���[�̃��C�Y�z��0���傫��������
            m_lastBidPlayer = true;
            //else
            m_lastBidPlayer = false;
        }

        m_playerTurnFreamCount+=Time.deltaTime;
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

        //�O�b�Y�̃J�����g�ɑ���
        var goods = m_goods.GetComponent<Goods>();
        goods.SetCurrentMoney(goods.GetCurrentMoney() + maxBidNum);

        m_bidCount = bidCount;
        m_turn = TURN.CHECK_TURN;
    }

    private void CheckTurn()
    {
        //Loop����ɍs�����Ƃ�
        if (m_loopNum == m_nowLoopNum)
        {
            m_turn = TURN.END_TURN;
        }

        //�x�b�g�����q�����Ȃ������Ƃ�
        if(m_bidCount == 0)
        {
            m_turn = TURN.END_TURN;
        }
    }

    private void EndTurn()
    {
        //�v���C���[���Ōゾ������O�b�Y�̃J�����g�z����
        //�q���Ōゾ������O�b�Y�̃J�����g�z����
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
}
