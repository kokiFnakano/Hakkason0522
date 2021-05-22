using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;




public class MoneyButton : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
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
        GetComponent<RectTransform>().localScale = new Vector3(minScale, minScale, minScale);
    }






    public int GetValue()
    {
        return value;
    }

    public void Reset()
    {

    }
}
