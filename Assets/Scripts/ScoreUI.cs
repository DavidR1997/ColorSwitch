using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ColorSwitch
{
    public class ScoreUI : MonoBehaviour
    {
        public Text scoreText;
        public int number;
        public int Value
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                RefreshText(value);
            }
        }
        public void Start()
        {
            scoreText = GetComponent<Text>() ;
            GameManager.Instance.scoreAdded += RefreshText;
            RefreshText(number);
        }

        public void RefreshText(int num)
        {
            scoreText.text = ""+ num.ToString();
        }
    }
}
