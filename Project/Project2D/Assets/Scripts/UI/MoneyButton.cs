using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;




public class MoneyButton : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    [SerializeField] EventSystem eventSystem;


    [SerializeField] int value;

    [SerializeField] float minScale;
    [SerializeField] float maxScale;


    Button button;
    CanvasRenderer cr;




    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        cr = GetComponent<CanvasRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }



    
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<RectTransform>().localScale = new Vector3(maxScale, maxScale, maxScale);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //try
        //{
        //    if (eventSystem.currentSelectedGameObject.gameObject != gameObject)
                GetComponent<RectTransform>().localScale = new Vector3(minScale, minScale, minScale);
        //}
        //catch (NullReferenceException ex)
        //{
        //    Debug.Log("No one selected");
        //}
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if(EventSystem)

        //イベントに選択されたオブジェクトがない場合
        GetComponent<RectTransform>().localScale = new Vector3(maxScale, maxScale, maxScale);
        EventSystem.current.SetSelectedGameObject(gameObject);

    }



    public int GetValue()
    {
        return value;
    }

    public void Reset()
    {

    }
}
