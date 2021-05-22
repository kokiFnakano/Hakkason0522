using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Player : MonoBehaviour
{
    [SerializeField] List<MoneyButton> buttons;


    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(EventSystem.current.currentSelectedGameObject == null)
            EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
    }



    //ベットした値を取得
    public int GetRaiseValue()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        return EventSystem.current.currentSelectedGameObject.GetComponent<MoneyButton>().GetValue();
    }



    //ボタンの選択フラグをオフにする
    public void ResetButtons()
    {
        EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
    }




    public void SetBetButtonsEnable(bool enable)
    {
        foreach(MoneyButton mb in buttons)
        {
            mb.gameObject.SetActive(enable);
        }
    }
}
