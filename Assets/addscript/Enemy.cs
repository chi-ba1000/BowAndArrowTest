using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int HC = 0;
    private int arrownum = 0;
    public int HP = 100; // 敵の初期HP
    public int arrowDamage = 10; // 矢のダメージ量
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("arrow"))
        {
            HC++;
            if (HC == 1)
            {
                collision.transform.SetParent(transform);
                // 矢の子オブジェクトの数を数える
                int arrowCount = 0;

                foreach (Transform child in gameObject.transform)
                {
                    if (child.CompareTag("arrow"))
                    {
                        arrowCount++;
                    }
                }
                int culentdam = 0;
                culentdam = arrowCount - arrownum;
                arrownum = arrowCount;
                Debug.Log("culentdam;" + arrowCount);

                // 矢の数に応じたダメージを計算
                int totalDamage = culentdam * arrowDamage;
                HP -= totalDamage;

                Debug.Log("受けたダメージ: " + totalDamage);
                Debug.Log("残りHP: " + HP);


                // HPが0以下ならこの敵オブジェクトを削除
                if (HP <= 0)
                {
                    Destroy(gameObject);
                    Debug.Log("敵が倒されました");
                    ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
                    scoreManager.AddScore(100);
                }
                HC = 0;
            }
        }
        Debug.Log("Hit object: " + collision.gameObject.name);
        //Debug.Log("Collision point: " + collision.contacts[0].point);
        Debug.Log("Collision normal: " + collision.contacts[0].normal);
    }
}

