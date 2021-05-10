using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public Transform ItemGrid;
    public List<GameObject> Items;

    public void CloseShop()
    {
        Destroy(gameObject);
    }
}
