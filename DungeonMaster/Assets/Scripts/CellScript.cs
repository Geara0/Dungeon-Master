using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.QuickSearch;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class CellScript : MonoBehaviour
{
    public bool hasTower = false;
    public Color baseColor;
    public Color currColor;

    public GameObject TowerPref;
    public GameObject ShopPref;

    public void BuildDot()
    {
        //var tmpTower = Instantiate(gameObject.AddComponent<DotBehaviour>());
        var tmpTower = Instantiate(TowerPref, transform, false);
        tmpTower.transform.position = transform.position;
        hasTower = true;
    }
    
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
            shopObj.transform.SetParent(GameObject.Find("ShopCanvas").transform, false);
            shopObj.GetComponent<ShopScript>().selfCell = this;
        }
    }
}
