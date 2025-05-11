using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public InputField playerNameInput;
    public Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        string playerName = playerNameInput.text;

        if (!string.IsNullOrEmpty(playerName))
        {
            PlayerPrefs.SetString("PlayerName", playerName); // プレイヤーネームを保存

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            SceneManager.LoadScene("Gamescene"); // ゲームシーンに遷移
        }
        else
        {
            Debug.LogWarning("プレイヤー名を入力してください。"); // エラーメッセージ
        }
    }
}
