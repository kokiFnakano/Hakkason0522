using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;




public class MoneyButton : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    [SerializeField] int value;

    [SerializeField] float minScale;
    [SerializeField] float maxScale;


    Button button;
    CanvasRenderer cr;

    AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        cr = GetComponent<CanvasRenderer>();

        audioSource = GetComponent<AudioSource>();

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
    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.Play();
    }




    public int GetValue()
    {
        return value;
    }

    public void Reset()
    {

    }
}
