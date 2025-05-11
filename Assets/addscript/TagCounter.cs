using UnityEngine;

public class TagCounter : MonoBehaviour
{
    public Transform parentObject;  // カウント対象の親オブジェクト
    public string targetTag = "TargetTag"; // カウントしたいタグの名前
    private int count = 0;
    // 特定のタグが付いた子オブジェクトの数を返すメソッド
    void Update()
    {
        count = CountTaggedChildren(); // スクリプト開始時にカウント
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.AddScore(count);
        count = 0;
    }

    public int CountTaggedChildren()
    {
        int count = 0;

        // 親オブジェクトの全ての子オブジェクトをチェック
        foreach (Transform child in parentObject)
        {
            if (child.CompareTag(targetTag))
            {
                count++;
            }
        }

        Debug.Log("タグ " + targetTag + " が付いた子オブジェクトの数: " + count);
        return count;
    }
}
