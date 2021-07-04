using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Transform player;
    public static int score;
    private void Start()
    {
        score = 0;
    }
    private void Update()
    {
        scoreText.text = score.ToString("0");
    }
    public static void addScore(int add)
    {
        score += add;
    }
}
