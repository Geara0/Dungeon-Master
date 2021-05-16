using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public Transform ItemGrid;
    public DotBehaviour Dot;
    public CellScript selfCell;

    public void CloseShop()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        
    }
}