using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    [SerializeField] List<MoneyButton> buttons;




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
        foreach(MoneyButton mb in buttons)
        {
            if (mb.enabled)
                return mb.GetValue();
        }

        //ベットなし
        return 0;
    }



    //ボタンの選択フラグをオフにする
    public void ResetButtons()
    {
        foreach (MoneyButton mb in buttons)
        {
            //if (mb.enabled)
            //    mb.GetComponent<Button>().
        }
    }
}
