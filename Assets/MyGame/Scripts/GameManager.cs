using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOverPanel;
    public Text scoreText;
    int score = 0;
    const string mainSceneKeyword = "MainScene";
    const string menuSceneKeyword = "MenuScene";

    // Called once on Gamestart, sets instance variable
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Called on GameOver, calls StopScrolling, stops obstacle spawning and activates gameover panel
    public void GameOver()
    {
        ObstacleSpawner.instance.isGameOver = true;
        StopScrolling();
        gameOverPanel.SetActive(true);
    }

    // Called if GameOver is true, stops background scrolling
    void StopScrolling()
    {
        TextureScroll[] scrollingObjects = FindObjectsOfType<TextureScroll>();

        foreach(TextureScroll item in scrollingObjects)
        {
            item.scrollBackground = false;
            Debug.Log(item.name);
        }
    }

    // Called on Restart, sets MainScene
    public void Restart()
    {
        SceneManager.LoadScene(mainSceneKeyword);
    }

    // Called on Menu, sets MenuScene
    public void Menu()
    {
        SceneManager.LoadScene(menuSceneKeyword);
    }

    // Counts and shows score
    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
