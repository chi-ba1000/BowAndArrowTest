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
            PlayerPrefs.SetString("PlayerName", playerName); // �v���C���[�l�[����ۑ�

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            SceneManager.LoadScene("Gamescene"); // �Q�[���V�[���ɑJ��
        }
        else
        {
            Debug.LogWarning("�v���C���[������͂��Ă��������B"); // �G���[���b�Z�[�W
        }
    }
}
