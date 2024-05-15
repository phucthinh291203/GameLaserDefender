using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    ScoreKeeping score;
    void Awake()
    {
        score = FindObjectOfType<ScoreKeeping>();
    }
    public void LoadGame()
    {
        score.ResetScore();
        SceneManager.LoadScene("Game");
        
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", 2f));
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName,float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneName);
    }
}
