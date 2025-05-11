using UnityEngine;

public class TagCounter : MonoBehaviour
{
    public Transform parentObject;  // �J�E���g�Ώۂ̐e�I�u�W�F�N�g
    public string targetTag = "TargetTag"; // �J�E���g�������^�O�̖��O
    private int count = 0;
    // ����̃^�O���t�����q�I�u�W�F�N�g�̐���Ԃ����\�b�h
    void Update()
    {
        count = CountTaggedChildren(); // �X�N���v�g�J�n���ɃJ�E���g
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.AddScore(count);
        count = 0;
    }

    public int CountTaggedChildren()
    {
        int count = 0;

        // �e�I�u�W�F�N�g�̑S�Ă̎q�I�u�W�F�N�g���`�F�b�N
        foreach (Transform child in parentObject)
        {
            if (child.CompareTag(targetTag))
            {
                count++;
            }
        }

        Debug.Log("�^�O " + targetTag + " ���t�����q�I�u�W�F�N�g�̐�: " + count);
        return count;
    }
}
