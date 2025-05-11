using UnityEngine;

public class BowAndArrow : MonoBehaviour
{
    public GameObject arrowPrefab; // 矢のPrefab
    public Transform arrowSpawnPoint; // 矢の発射位置
    public float maxArrowForce = 20f; // 矢に加える最大力
    private float currentForce = 0f; // 現在の力
    public Transform target; // 目標のTransform（ターゲットの位置）

    // x軸の補正角度
    public float xAxisCorrectionAngle = 10f;

    void Update()
    {
        // マウスの左ボタンを押し続けて力を溜める
        if (Input.GetMouseButton(0))
        {
            currentForce += Time.deltaTime * maxArrowForce; // 力を溜める
            currentForce = Mathf.Clamp(currentForce, 0f, maxArrowForce); // 最大力で制限
        }

        // 左ボタンを離したら矢を発射
        if (Input.GetMouseButtonUp(0))
        {
            ShootArrow();
            currentForce = 0f; // 力をリセット
        }
    }

    void ShootArrow()
    {
        if (target == null) return; // 目標が設定されていない場合は発射しない

        // 目標の方向を計算
        Vector3 directionToTarget = (target.position - arrowSpawnPoint.position).normalized;

        // 目標の方向を向くように矢の回転を設定
        Quaternion arrowRotation = Quaternion.LookRotation(directionToTarget);

        // x軸に90度回転を追加
        Quaternion xAxisRotation = Quaternion.Euler(90f, 0f, 0f);
        Quaternion finalRotation = arrowRotation * xAxisRotation;

        // 矢を生成し、指定した回転で配置
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, finalRotation);
        Rigidbody rb = arrow.GetComponent<Rigidbody>();

        // 矢に力を加えて発射
        rb.AddForce(directionToTarget * currentForce, ForceMode.Impulse);
    }
}
