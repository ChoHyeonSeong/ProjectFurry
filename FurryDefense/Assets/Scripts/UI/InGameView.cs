using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InGameView : MonoBehaviour
{
    [SerializeField]
    private EventTrigger _unitTrigger;

    private void Awake()
    {

    }

    private void OnClick()
    {
        Debug.Log("Click");
    }

    private void OnDown()
    {
        Debug.Log("Down");
    }

    private void OnUp()
    {
        Debug.Log("Up");
    }
}
