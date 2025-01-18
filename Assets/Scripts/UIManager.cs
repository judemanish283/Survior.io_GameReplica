using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Action HandleGameUIUpdate;

    [SerializeField] TMP_Text ScoreText,CoinText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        HandleGameUIUpdate += OnGameUIUpdate;
    }

    void OnGameUIUpdate()
    {
        ScoreText.text = $"Score : {PlayerController.Instance.playerData.playerScore}"; 
        CoinText.text = $"Gold : {PlayerController.Instance.playerData.playerCoins}"; 
    }
}
