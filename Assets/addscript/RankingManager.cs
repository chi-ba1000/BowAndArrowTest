using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class RankingManager : MonoBehaviour
{
    public TextMeshProUGUI rankingText;

    void Start()
    {
        LoadAndDisplayScores();
    }

    private void LoadAndDisplayScores()
    {
        string path = Application.persistentDataPath + "/scores.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ScoreList loadedData = JsonUtility.FromJson<ScoreList>(json);

            // �X�R�A���~���Ń\�[�g
            List<ScoreEntry> sortedScores = loadedData.scores;
            sortedScores.Sort((x, y) => y.score.CompareTo(x.score));

            rankingText.text = "Ranking:\n";
            for (int i = 0; i < sortedScores.Count; i++)
            {
                ScoreEntry entry = sortedScores[i];
                rankingText.text += (i + 1) + ". " + entry.playerName + ": " + entry.score + "\n"; // �ԍ���t���ĕ\��
            }
        }
        else
        {
            rankingText.text = "No scores available.";
        }
    }
}
