using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // TextMeshProUGUIの参照
    public float countdownTime = 60f; // カウントダウンの初期時間（秒）
    public GameObject gameOverUI;
    public GameObject gameClearUI;

    private float timeRemaining; // 残り時間
    private int triger = 0;

    void Start()
    {
        timeRemaining = countdownTime; // 初期化
        UpdateTimerText(); // 初期表示
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // 残り時間を減少
            UpdateTimerText(); // タイマーを更新
        }
        else
        {
            if (triger == 0)
            {
                triger++;
                // タイマーがゼロになった場合の処理
                TimerEnded();
            }          
        }
    }

    private void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Max(timeRemaining, 0).ToString("F1"); // 残り時間を表示
    }

    private void TimerEnded()
    {
        timerText.text = "Time: 0.0"; // ゼロになった時の表示
        // タイマー終了後の処理をここに追加
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.AddScore(10000);
        Debug.Log("タイマーが終了しました！");
        bonus Bonus = FindObjectOfType<bonus>();
        Bonus.Bonus();
        // ゲームオーバーUIを表示
        gameClearUI.SetActive(true);
        Player player = FindObjectOfType<Player>();
        player.GameOver();
    }
}
