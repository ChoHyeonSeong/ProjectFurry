using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InGameView : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _landingBtnList;


    public void ActiveLandingButton(int index)
    {
        _landingBtnList[index].SetActive(true);
    }
}
