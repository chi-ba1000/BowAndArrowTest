using UnityEngine;
using UnityEngine.UI; // UI�p
using System.Collections;

public class Player : MonoBehaviour
{
    public int HP = 100; // �v���C���[�̏���HP
    private int HC = 99;
    public float invulnerabilityDuration = 1.0f; // �_���[�W���󂯂���̖��G����
    private bool isInvulnerable = false; // ���G��Ԃ��Ǘ�����t���O
    public Slider hpSlider;

    // �Q�[���I�[�o�[�p��UI
    public GameObject gameOverUI;
    public GameObject redOverlay; // �Ԃ��I�[�o�[���C�p��Image

    void Start()
    {
        redOverlay.SetActive(false); // �Q�[���J�n���ɐԂ��I�[�o�[���C���\����
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
                // �G����̃_���[�W���󂯂鏈��
                TakeDamage(10); // ��: �G����10�̃_���[�W���󂯂�
                HC = 0;
            }
        }
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("up"))
        {
            // ���݂̈ʒu���擾
            Vector3 currentPosition = transform.position;

            // Y���̍�����0.1���₷
            currentPosition.y += 0.5f;

            // �V�����ʒu��K�p
            transform.position = currentPosition;
        }
    }


    private void TakeDamage(int damage)
    {
        if (!isInvulnerable)
        {
            HP -= damage; // �_���[�W���󂯂�
            hpSlider.value = HP;
            Debug.Log("�_���[�W���󂯂��I�c��HP: " + HP);
            ShowRedOverlay(); // �Ԃ��I�[�o�[���C��\��

            // ���G��Ԃɂ���
            StartCoroutine(InvulnerabilityCoroutine());

            // HP��0�ɂȂ�����Q�[���I�[�o�[
            if (HP <= 0)
            {
                GameOver();
            }
        }
    }

    private IEnumerator InvulnerabilityCoroutine()
    {
        isInvulnerable = true; // ���G��Ԃ�
        yield return new WaitForSeconds(invulnerabilityDuration); // �w�肵�����ԑ҂�
        isInvulnerable = false; // ���G��Ԃ�����
    }

    private void ShowRedOverlay()
    {
        redOverlay.SetActive(true); // �Ԃ��I�[�o�[���C��\��
        StartCoroutine(HideRedOverlay()); // ��莞�Ԍ�ɃI�[�o�[���C���B��
    }

    private IEnumerator HideRedOverlay()
    {
        yield return new WaitForSeconds(0.5f); // �Ԃ��I�[�o�[���C���\������Ă���ҋ@
        redOverlay.SetActive(false); // �Ԃ��I�[�o�[���C���\����
    }

    public void GameOver()
    {
        // �Q�[���I�[�o�[UI��\��
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("�Q�[���I�[�o�[�I");

        // �v���C���[���\���ɂ���
        gameObject.SetActive(false); // �v���C���[�I�u�W�F�N�g���\���ɂ���
        Cursor.visible = true; // �J�[�\����\��
        Cursor.lockState = CursorLockMode.None; // �J�[�\���̃��b�N������
    }
}
