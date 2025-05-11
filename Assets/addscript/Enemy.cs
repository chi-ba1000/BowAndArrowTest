using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int HC = 0;
    private int arrownum = 0;
    public int HP = 100; // �G�̏���HP
    public int arrowDamage = 10; // ��̃_���[�W��
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("arrow"))
        {
            HC++;
            if (HC == 1)
            {
                collision.transform.SetParent(transform);
                // ��̎q�I�u�W�F�N�g�̐��𐔂���
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

                // ��̐��ɉ������_���[�W���v�Z
                int totalDamage = culentdam * arrowDamage;
                HP -= totalDamage;

                Debug.Log("�󂯂��_���[�W: " + totalDamage);
                Debug.Log("�c��HP: " + HP);


                // HP��0�ȉ��Ȃ炱�̓G�I�u�W�F�N�g���폜
                if (HP <= 0)
                {
                    Destroy(gameObject);
                    Debug.Log("�G���|����܂���");
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

