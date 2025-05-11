using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true; // カーソルを表示
            Cursor.lockState = CursorLockMode.None; // カーソルのロックを解除
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        bool isActive = pauseMenuUI.activeSelf;
        pauseMenuUI.SetActive(true);
        Time.timeScale = isActive ? 1 : 0; // ポーズ
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.SaveScore();
        SceneManager.LoadScene("MainMenu");
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Gamescene"); // ゲームシーンに遷移
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.ResetScore();
    }
}
