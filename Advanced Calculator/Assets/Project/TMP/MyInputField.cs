using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyInputField : TMP_InputField
{
    public override void OnDeselect(BaseEventData eventData)
    {
        PointerEventData eventData1 = new PointerEventData(EventSystem.current);
        eventData1.pointerClick = gameObject;
        this.OnPointerClick(eventData1);
    }
    public override void OnPointerExit(PointerEventData eventData)
    {

    }
}
