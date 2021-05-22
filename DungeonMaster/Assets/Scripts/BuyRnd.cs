using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using Image = UnityEngine.UI.Image;

public class BuyRnd : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public RndBehaviour rndPrefab;

    private CellScript selfCell;

    public Image logo;
    public Text price;

    public Color BaseColor, CurrColor;

    public void Start()
    {
        logo.sprite = rndPrefab.GetComponent<SpriteRenderer>().sprite;
        price.text = rndPrefab.price.ToString();
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().color = CurrColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = BaseColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (MoneyManager.Instance.GameMoney >= rndPrefab.price)
        {
            GetComponentInParent<ShopScript>().selfCell.BuildRnd();
            
            MoneyManager.Instance.GameMoney -= rndPrefab.price;
            MoneyManager.Instance.MoneyTxt.text = MoneyManager.Instance.GameMoney.ToString();
            Destroy(transform.parent.gameObject);
        }
    }
}