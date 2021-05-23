using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    public Text MoneyTxt;

    public int GameMoney;

    private void Awake()
    {
        Instance = this;
    }
}
