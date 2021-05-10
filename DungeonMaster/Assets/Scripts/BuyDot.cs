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
    public Image logo;
    public Text price;

    public Color BaseColor, CurrColor;

    public void Start()
    {
        logo.sprite = dotPrefab.GetComponent<SpriteRenderer>().sprite;
        price.text = dotPrefab.price.ToString();
    }
    /*
    public void SetStartData(DotBehaviour dot)
    {
        dotPrefab = dot;
        logo.sprite = dot.projectilePrefab.GetComponent<SpriteRenderer>().sprite;
        price.text = dot.price.ToString();
    }
    */
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
        throw new NotImplementedException();
    }
}
