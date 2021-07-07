using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public Text scoreText;

    public static GameController instance;
    public GameObject gameOver;

    // Start is called before the first frame update
    private void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    private void Update()
    {
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