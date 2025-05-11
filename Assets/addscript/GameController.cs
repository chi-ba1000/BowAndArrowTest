using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true; // �J�[�\����\��
            Cursor.lockState = CursorLockMode.None; // �J�[�\���̃��b�N������
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        bool isActive = pauseMenuUI.activeSelf;
        pauseMenuUI.SetActive(true);
        Time.timeScale = isActive ? 1 : 0; // �|�[�Y
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
        SceneManager.LoadScene("Gamescene"); // �Q�[���V�[���ɑJ��
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.ResetScore();
    }
}
