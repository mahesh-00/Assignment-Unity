using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class GameTimer : MonoBehaviour
    {
        [SerializeField]private float gameTime = 120;
        private bool isStartTime = false;

        private static GameTimer _instance;

        public static GameTimer Instance => _instance;


        private void Awake()
        {
            _instance = this;
        }

        private void OnDestroy()
        {
            if (_instance != null)
            {
                _instance = null;
            }
        }

        private void Update()
        {
            if (isStartTime)
            {
                gameTime -= Time.deltaTime;
            }
        }

        public void StartTimer()
        {
            isStartTime = true;
        }

        public void StopTimer()
        {
            isStartTime = false;
        }

        public string GetTime()
        {
            float minutes = Mathf.FloorToInt(gameTime / 60);
            float seconds = Mathf.FloorToInt(gameTime % 60);
            string time = string.Format("{0:00}:{1:00}", minutes, seconds);
            return time;
        }

    }
