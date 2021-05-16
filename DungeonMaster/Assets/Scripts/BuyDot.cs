using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using Image = UnityEngine.UI.Image;

public class BuyDot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public DotBehaviour dotPrefab;

    private CellScript selfCell;

    public Image logo;
    public Text price;

    public Color BaseColor, CurrColor;

    public void Start()
    {
        logo.sprite = dotPrefab.GetComponent<SpriteRenderer>().sprite;
        price.text = dotPrefab.price.ToString();
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
        if (MoneyManager.Instance.GameMoney >= dotPrefab.price)
        {
            GetComponentInParent<ShopScript>().selfCell.BuildDot();
            
            MoneyManager.Instance.GameMoney -= dotPrefab.price;
            MoneyManager.Instance.MoneyTxt.text = MoneyManager.Instance.GameMoney.ToString();
            Destroy(transform.parent.gameObject);
        }
    }
}
