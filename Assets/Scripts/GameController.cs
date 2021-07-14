using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public Text scoreText;

    public static GameController instance;
    public GameObject gameOver;
    
    private void Start()
    {
        instance = this;
    }

    public void NewGame()
    {
        SceneManager.LoadScene("lvl_1");
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGame()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}