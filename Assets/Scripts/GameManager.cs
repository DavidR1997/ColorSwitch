using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

namespace ColorSwitch
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        public static GameManager Instance = null;
        public bool isGameOver = false;
        public int score = 0;
        public delegate void IntCallBack(int number);
        public IntCallBack scoreAdded;
        // Use this for initialization
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        private void OnDestroy()
        {
            Instance = null;
        }
        #endregion

        public void ResetGame()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
        public void AddScore(int scoreToAdd)
        {
            if (isGameOver)
                return;

            score += scoreToAdd;

            scoreAdded.Invoke(score);
        }
    }
}