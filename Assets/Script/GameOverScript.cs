using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Text pointsText;
    public GameObject highestScoreTxt;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "Score : " + score.ToString();

        if (PlayerPrefs.GetInt("HighScore", 0) < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highestScoreTxt.SetActive(true);
        }
        else
        {
            highestScoreTxt.SetActive(false);
        }
        
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
