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
    public int score = 0; // �X�R�A�̏����l��0�ɐݒ�
    public string playername;

    private const string saveFileName = "scores.json";
    private List<ScoreEntry> scoreEntries = new List<ScoreEntry>();

    void Start()
    {
        LoadScores(); // �X�R�A��ǂݍ���
        UpdateScoreDisplay();
    }

    public void SetName(string name)
    {
        playername = name;
        Debug.Log("�ۑ����܂���");
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreDisplay();
        Debug.Log("���݂̃X�R�A: " + score);
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
        // �X�R�A�G���g�����쐬
        ScoreEntry newEntry = new ScoreEntry(playername, score);
        bool scoreUpdated = false;

        // �����̃X�R�A�Ɣ�r
        for (int i = 0; i < scoreEntries.Count; i++)
        {
            // �����v���C���[�������ɑ��݂���ꍇ
            if (scoreEntries[i].playerName == playername)
            {
                // �V�����X�R�A�������ꍇ�A�㏑��
                if (newEntry.score > scoreEntries[i].score)
                {
                    scoreEntries[i] = newEntry; // �V�����X�R�A�ŏ㏑��
                    scoreUpdated = true;
                }
                break; // ���[�v�𔲂���
            }
        }

        // �V�����X�R�A�G���g�����ǉ����ꂽ�ꍇ
        if (!scoreUpdated)
        {
            scoreEntries.Add(newEntry);
        }

        // JSON�ɃV���A���C�Y���ĕۑ�
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
