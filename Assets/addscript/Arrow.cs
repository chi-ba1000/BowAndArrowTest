using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody arrowRb;

    void Start()
    {
        arrowRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // 矢の速度があるときだけ方向を調整
        if (arrowRb.velocity.sqrMagnitude > 0.1f)
        {
            // 矢の現在の速度の方向に回転させる
            transform.rotation = Quaternion.LookRotation(arrowRb.velocity.normalized) * Quaternion.Euler(90f, 0f, 0f);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("object"))
        {
            // 矢を衝突したオブジェクトの子にする
            transform.SetParent(collision.transform);
            gameObject.tag = "Untagged";
            Debug.Log("ぐさっ");
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.AddScore(1);

            // Rigidbody を無効化して位置と回転を固定
            arrowRb.isKinematic = true;

        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            arrowRb.isKinematic = true;
        }
        Debug.Log("Hit object: " + collision.gameObject.name);
        //Debug.Log("Collision point: " + collision.contacts[0].point);
        Debug.Log("Collision normal: " + collision.contacts[0].normal);
        // プレイヤータグが付いていないオブジェクトに衝突した場合の処理


    }
}
