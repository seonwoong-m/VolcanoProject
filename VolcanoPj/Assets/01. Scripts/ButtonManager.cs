using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image button;

    public Sprite pushBtnImg;
    public Sprite BtnImg;

    public bool isPush;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPush = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPush = false;
    }

    void Update()
    {
        if(isPush)
        {
            button.sprite = pushBtnImg;
        }
        else
        {
            button.sprite = BtnImg;
        }
    }
}
