using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameWinPanel;

    private void Start()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
    }

    public void GamePause()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }   
    }

    public void GameResume()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void GameWin()
    {
        Time.timeScale = 0f;
        gameWinPanel.SetActive(true);
    }

    public void GameRestart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void Update()
    {
        GamePause();
    }
}
