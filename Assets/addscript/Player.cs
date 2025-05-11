using UnityEngine;
using UnityEngine.UI; // UI用
using System.Collections;

public class Player : MonoBehaviour
{
    public int HP = 100; // プレイヤーの初期HP
    private int HC = 99;
    public float invulnerabilityDuration = 1.0f; // ダメージを受けた後の無敵時間
    private bool isInvulnerable = false; // 無敵状態を管理するフラグ
    public Slider hpSlider;

    // ゲームオーバー用のUI
    public GameObject gameOverUI;
    public GameObject redOverlay; // 赤いオーバーレイ用のImage

    void Start()
    {
        redOverlay.SetActive(false); // ゲーム開始時に赤いオーバーレイを非表示に
        hpSlider.maxValue = HP;
        hpSlider.value = HP;
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(HC);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HC++;
            if (HC == 100)
            {
                // 敵からのダメージを受ける処理
                TakeDamage(10); // 例: 敵から10のダメージを受ける
                HC = 0;
            }
        }
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("up"))
        {
            // 現在の位置を取得
            Vector3 currentPosition = transform.position;

            // Y軸の高さを0.1増やす
            currentPosition.y += 0.5f;

            // 新しい位置を適用
            transform.position = currentPosition;
        }
    }


    private void TakeDamage(int damage)
    {
        if (!isInvulnerable)
        {
            HP -= damage; // ダメージを受ける
            hpSlider.value = HP;
            Debug.Log("ダメージを受けた！残りHP: " + HP);
            ShowRedOverlay(); // 赤いオーバーレイを表示

            // 無敵状態にする
            StartCoroutine(InvulnerabilityCoroutine());

            // HPが0になったらゲームオーバー
            if (HP <= 0)
            {
                GameOver();
            }
        }
    }

    private IEnumerator InvulnerabilityCoroutine()
    {
        isInvulnerable = true; // 無敵状態に
        yield return new WaitForSeconds(invulnerabilityDuration); // 指定した時間待つ
        isInvulnerable = false; // 無敵状態を解除
    }

    private void ShowRedOverlay()
    {
        redOverlay.SetActive(true); // 赤いオーバーレイを表示
        StartCoroutine(HideRedOverlay()); // 一定時間後にオーバーレイを隠す
    }

    private IEnumerator HideRedOverlay()
    {
        yield return new WaitForSeconds(0.5f); // 赤いオーバーレイが表示されてから待機
        redOverlay.SetActive(false); // 赤いオーバーレイを非表示に
    }

    public void GameOver()
    {
        // ゲームオーバーUIを表示
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("ゲームオーバー！");

        // プレイヤーを非表示にする
        gameObject.SetActive(false); // プレイヤーオブジェクトを非表示にする
        Cursor.visible = true; // カーソルを表示
        Cursor.lockState = CursorLockMode.None; // カーソルのロックを解除
    }
}
