using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    // �A�j���[�^�[�̎Q�Ƃ�����
    private Animator animator;

    void Start()
    {
        // �A�^�b�`���ꂽAnimator�R���|�[�l���g���擾
        animator = GetComponent<Animator>();
    }
    //45, 0, -90
    void Update()
    {
        // ���N���b�N�����o
        if (Input.GetMouseButtonDown(0))
        {
            // �A�j���[�V�������g���K�[
            animator.SetTrigger("Bow_charge");
        }
        // �N���b�N�������ꂽ����bool��false�ɐݒ�i�I�v�V�����j
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetTrigger("Bow_fire");
        }
    }
}
