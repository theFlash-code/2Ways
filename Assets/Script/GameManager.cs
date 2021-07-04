using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameOverScript gameOverScript;
    bool gameHasEnded = false;
    public float restartDelay = 3f;
    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            gameOverScript.Setup(Score.score);
            //Invoke("Restart", restartDelay);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
