using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Net.Sockets;
public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider sliderBar;
    [SerializeField] Health healthPlayer;

    [Header("Score")]
    ScoreKeeping score;
    [SerializeField] TextMeshProUGUI scoreText;
    void Awake()
    {
        score = FindObjectOfType<ScoreKeeping>();
    }
    void Start()
    {
        sliderBar.maxValue = healthPlayer.GetCurrentHealth();
    }

    void Update()
    {
        sliderBar.value = healthPlayer.GetCurrentHealth();
        scoreText.text = score.GetScore().ToString();
    }
}
