using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.QuickSearch;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class CellScript : MonoBehaviour
{
    public bool hasTower = false;
    public Color baseColor;
    public Color currColor;

    public GameObject DotPrefab;
    public GameObject RndPrefab;
    public GameObject ShopPref;

    public Scene scene;

    public void BuildDot()
    {
        //var tmpTower = Instantiate(gameObject.AddComponent<DotBehaviour>());
        var tmpTower = Instantiate(DotPrefab, transform, false);
        tmpTower.transform.position = transform.position;
        hasTower = true;
    }
    
    public void BuildRnd()
    {
        //var tmpTower = Instantiate(gameObject.AddComponent<DotBehaviour>());
        var tmpTower = Instantiate(RndPrefab, transform, false);
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
        Destroy(GameObject.Find("Shop(Clone)"));
        if (!hasTower)
        {
            var shopObj = Instantiate(ShopPref);
            shopObj.transform.SetParent(GameObject.Find("ShopCanvas").transform, false);
            shopObj.GetComponent<ShopScript>().selfCell = this;
        }
    }
}
