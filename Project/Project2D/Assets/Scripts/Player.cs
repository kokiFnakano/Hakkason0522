using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Player : MonoBehaviour
{
    [SerializeField] MoneyButton defaultButton;


    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(defaultButton.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(EventSystem.current.currentSelectedGameObject == null)
            EventSystem.current.SetSelectedGameObject(defaultButton.gameObject);
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
        EventSystem.current.SetSelectedGameObject(defaultButton.gameObject);
    }
}
