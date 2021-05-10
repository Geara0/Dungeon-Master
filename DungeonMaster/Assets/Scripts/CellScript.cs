using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class CellScript : MonoBehaviour
{
    public bool hasTower = false;
    public Color baseColor;
    public Color currColor;

    public GameObject ShopPref;
    
    private void OnMouseEnter()
    {
        if (!hasTower)
            GetComponent<SpriteRenderer>().color = currColor;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = baseColor;
    }

    private void OnMouseDown()
    {
        if (!hasTower)
        {
            var shopObj = Instantiate(ShopPref);
            shopObj.transform.SetParent(GameObject.Find("Canvas").transform, false);
        }
    }
}
