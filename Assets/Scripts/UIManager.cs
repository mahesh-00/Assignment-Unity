using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    private static UIManager _instance;
    public static UIManager Instance => _instance;
    private int score ;

    public Action OnEnemyKilled;
    public Action OnGameWon;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private GameObject _gameWonScreenGO;
    [SerializeField] private TextMeshProUGUI _gameEndText;

    private void Awake() 
    {
        if(_instance == null)
            _instance = this;
        else
            Destroy(this);
    }

    private void Start() 
    {
        OnEnemyKilled += UpdateScore;
        OnGameWon += ShowGameWonUI;
        GameTimer.Instance?.StartTimer();
    }


    private void Update() 
    {
        _timerText.text = GameTimer.Instance?.GetTime();
    }

    private void OnDisable() 
    {
        OnEnemyKilled -= UpdateScore;
         OnGameWon -= ShowGameWonUI;   
    }

    private void UpdateScore()
    {
        score++;
        _scoreText.text = "Score: "+ score;
    }

    
    private void ShowGameWonUI()
    {
       _gameWonScreenGO.SetActive(true);
       _gameEndText.text = "YOU WON";
       GameTimer.Instance.StopTimer();
    }
}
