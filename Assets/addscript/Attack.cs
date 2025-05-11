using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    // アニメーターの参照を持つ
    private Animator animator;

    void Start()
    {
        // アタッチされたAnimatorコンポーネントを取得
        animator = GetComponent<Animator>();
    }
    //45, 0, -90
    void Update()
    {
        // 左クリックを検出
        if (Input.GetMouseButtonDown(0))
        {
            // アニメーションをトリガー
            animator.SetTrigger("Bow_charge");
        }
        // クリックが放された時にboolをfalseに設定（オプション）
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetTrigger("Bow_fire");
        }
    }
}
