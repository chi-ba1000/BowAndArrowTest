using UnityEngine;

public class Homing : MonoBehaviour
{
    Transform playerTr; // プレイヤーのTransform
    public float speed = 2; // 敵の動くスピード

    private void Start()
    {
        // プレイヤーのTransformを取得（プレイヤーのタグをPlayerに設定必要）
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {

        // プレイヤーとの距離が0.1f未満になったらそれ以上実行しない
        if (Vector3.Distance(transform.position, playerTr.position) < 0)
            return;

        // プレイヤーに向けて進む
        transform.position = Vector3.MoveTowards(
            transform.position,
            playerTr.position,
            speed * Time.deltaTime);
    }
}
