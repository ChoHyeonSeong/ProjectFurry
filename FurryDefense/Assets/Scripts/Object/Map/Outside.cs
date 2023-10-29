using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Outside : MonoBehaviour, IPointerClickHandler
{
    public static Action OnClickOutside { get; set; }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Outside OnMouseDown");
        OnClickOutside();
    }
}
