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
        // ��̑��x������Ƃ����������𒲐�
        if (arrowRb.velocity.sqrMagnitude > 0.1f)
        {
            // ��̌��݂̑��x�̕����ɉ�]������
            transform.rotation = Quaternion.LookRotation(arrowRb.velocity.normalized) * Quaternion.Euler(90f, 0f, 0f);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("object"))
        {
            // ����Փ˂����I�u�W�F�N�g�̎q�ɂ���
            transform.SetParent(collision.transform);
            gameObject.tag = "Untagged";
            Debug.Log("������");
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.AddScore(1);

            // Rigidbody �𖳌������Ĉʒu�Ɖ�]���Œ�
            arrowRb.isKinematic = true;

        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            arrowRb.isKinematic = true;
        }
        Debug.Log("Hit object: " + collision.gameObject.name);
        //Debug.Log("Collision point: " + collision.contacts[0].point);
        Debug.Log("Collision normal: " + collision.contacts[0].normal);
        // �v���C���[�^�O���t���Ă��Ȃ��I�u�W�F�N�g�ɏՓ˂����ꍇ�̏���


    }
}
