using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    private TextMeshProUGUI _text;
    public static int Coin;
    
    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        Coin = PlayerPrefs.GetInt("coins", Coin);
    }

    private void Update()
    {
        _text.text = Coin.ToString();
    }
}
