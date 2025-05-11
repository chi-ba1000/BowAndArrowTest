using UnityEngine;

public class BowAndArrow : MonoBehaviour
{
    public GameObject arrowPrefab; // ���Prefab
    public Transform arrowSpawnPoint; // ��̔��ˈʒu
    public float maxArrowForce = 20f; // ��ɉ�����ő��
    private float currentForce = 0f; // ���݂̗�
    public Transform target; // �ڕW��Transform�i�^�[�Q�b�g�̈ʒu�j

    // x���̕␳�p�x
    public float xAxisCorrectionAngle = 10f;

    void Update()
    {
        // �}�E�X�̍��{�^�������������ė͂𗭂߂�
        if (Input.GetMouseButton(0))
        {
            currentForce += Time.deltaTime * maxArrowForce; // �͂𗭂߂�
            currentForce = Mathf.Clamp(currentForce, 0f, maxArrowForce); // �ő�͂Ő���
        }

        // ���{�^���𗣂������𔭎�
        if (Input.GetMouseButtonUp(0))
        {
            ShootArrow();
            currentForce = 0f; // �͂����Z�b�g
        }
    }

    void ShootArrow()
    {
        if (target == null) return; // �ڕW���ݒ肳��Ă��Ȃ��ꍇ�͔��˂��Ȃ�

        // �ڕW�̕������v�Z
        Vector3 directionToTarget = (target.position - arrowSpawnPoint.position).normalized;

        // �ڕW�̕����������悤�ɖ�̉�]��ݒ�
        Quaternion arrowRotation = Quaternion.LookRotation(directionToTarget);

        // x����90�x��]��ǉ�
        Quaternion xAxisRotation = Quaternion.Euler(90f, 0f, 0f);
        Quaternion finalRotation = arrowRotation * xAxisRotation;

        // ��𐶐����A�w�肵����]�Ŕz�u
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, finalRotation);
        Rigidbody rb = arrow.GetComponent<Rigidbody>();

        // ��ɗ͂������Ĕ���
        rb.AddForce(directionToTarget * currentForce, ForceMode.Impulse);
    }
}
