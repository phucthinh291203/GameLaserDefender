using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeping : MonoBehaviour
{
    int CurrentScore;
    static ScoreKeeping instance;

    
    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetScore()
    {
        return CurrentScore;
    } 

    public void ModifyScore(int value)
    {
        CurrentScore += value;
        Mathf.Clamp(CurrentScore, 0, int.MaxValue);
    }
    
    public void ResetScore()
    {
        CurrentScore = 0;
    }
}
