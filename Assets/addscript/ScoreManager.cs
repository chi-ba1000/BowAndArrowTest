using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

[System.Serializable]
public class ScoreEntry
{
    public string playerName;
    public int score;

    public ScoreEntry(string name, int score)
    {
        this.playerName = name;
        this.score = score;
    }
}

[System.Serializable]
public class ScoreList
{
    public List<ScoreEntry> scores;
}

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score_object;
    public int score = 0; // スコアの初期値を0に設定
    public string playername;

    private const string saveFileName = "scores.json";
    private List<ScoreEntry> scoreEntries = new List<ScoreEntry>();

    void Start()
    {
        LoadScores(); // スコアを読み込む
        UpdateScoreDisplay();
    }

    public void SetName(string name)
    {
        playername = name;
        Debug.Log("保存しました");
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreDisplay();
        Debug.Log("現在のスコア: " + score);
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreDisplay();
    }

    public void SaveScore()
    {
        string playername = PlayerPrefs.GetString("PlayerName", "defaultName");
        PlayerPrefs.DeleteKey("PlayerName");
        // スコアエントリを作成
        ScoreEntry newEntry = new ScoreEntry(playername, score);
        bool scoreUpdated = false;

        // 既存のスコアと比較
        for (int i = 0; i < scoreEntries.Count; i++)
        {
            // 同じプレイヤー名が既に存在する場合
            if (scoreEntries[i].playerName == playername)
            {
                // 新しいスコアが高い場合、上書き
                if (newEntry.score > scoreEntries[i].score)
                {
                    scoreEntries[i] = newEntry; // 新しいスコアで上書き
                    scoreUpdated = true;
                }
                break; // ループを抜ける
            }
        }

        // 新しいスコアエントリが追加された場合
        if (!scoreUpdated)
        {
            scoreEntries.Add(newEntry);
        }

        // JSONにシリアライズして保存
        string json = JsonUtility.ToJson(new ScoreList { scores = scoreEntries });
        File.WriteAllText(Application.persistentDataPath + "/" + saveFileName, json);
    }

    private void LoadScores()
    {
        string path = Application.persistentDataPath + "/" + saveFileName;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ScoreList loadedData = JsonUtility.FromJson<ScoreList>(json);
            scoreEntries = loadedData.scores;
        }
    }

    private void UpdateScoreDisplay()
    {
        score_object.text = "Score: " + score;
    }
}
