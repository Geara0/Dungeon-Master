using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public Text ScoreTxt;

    public int GameScore;

    private void Awake()
    {
        Instance = this;
    }
}
