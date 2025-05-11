using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // TextMeshProUGUI�̎Q��
    public float countdownTime = 60f; // �J�E���g�_�E���̏������ԁi�b�j
    public GameObject gameOverUI;
    public GameObject gameClearUI;

    private float timeRemaining; // �c�莞��
    private int triger = 0;

    void Start()
    {
        timeRemaining = countdownTime; // ������
        UpdateTimerText(); // �����\��
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // �c�莞�Ԃ�����
            UpdateTimerText(); // �^�C�}�[���X�V
        }
        else
        {
            if (triger == 0)
            {
                triger++;
                // �^�C�}�[���[���ɂȂ����ꍇ�̏���
                TimerEnded();
            }          
        }
    }

    private void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Max(timeRemaining, 0).ToString("F1"); // �c�莞�Ԃ�\��
    }

    private void TimerEnded()
    {
        timerText.text = "Time: 0.0"; // �[���ɂȂ������̕\��
        // �^�C�}�[�I����̏����������ɒǉ�
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.AddScore(10000);
        Debug.Log("�^�C�}�[���I�����܂����I");
        bonus Bonus = FindObjectOfType<bonus>();
        Bonus.Bonus();
        // �Q�[���I�[�o�[UI��\��
        gameClearUI.SetActive(true);
        Player player = FindObjectOfType<Player>();
        player.GameOver();
    }
}
