using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    const string mainSceneKeyword = "MainScene";
  
    // Called on PlayStart, sets MainScene
    public void Play()
    {
        SceneManager.LoadScene(mainSceneKeyword);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
