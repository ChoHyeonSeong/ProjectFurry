using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationHandler : MonoBehaviour
{
    public List<int> HeroIdList { get; private set; }

    private void Awake()
    {
        HeroIdList = new List<int>
        {
            0
        };
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
}
