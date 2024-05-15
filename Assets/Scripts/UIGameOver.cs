using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIGameOver : MonoBehaviour
{
    ScoreKeeping score;
    [SerializeField] TextMeshProUGUI scoreText;
    void Awake()
    {
        score = FindObjectOfType<ScoreKeeping>();
    }

    void Start()
    {
        scoreText.text = "Your score: \n" + score.GetScore().ToString();
    }
}
