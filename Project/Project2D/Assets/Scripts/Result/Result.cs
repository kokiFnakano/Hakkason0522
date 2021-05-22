using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField]
    private GameObject m_textObject = null;

    private Text m_text = null;

    // Start is called before the first frame update
    void Start()
    {
        m_text = m_textObject.GetComponent<Text>();

        m_text.text = PlayerPrefs.GetInt("ResultScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
