using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text HighScoreTxt;
    private void Start()
    {
        HighScoreTxt.text = "Highest Score : "+PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ResetScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        HighScoreTxt.text = "Highest Score : " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
