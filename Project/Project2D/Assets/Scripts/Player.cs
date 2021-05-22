using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }



    //ベットした値を取得
    public int GetRaiseValue()
    {
        return EventSystem.current.currentSelectedGameObject.GetComponent<MoneyButton>().GetValue();
    }



    //ボタンの選択フラグをオフにする
    public void ResetButtons()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}
