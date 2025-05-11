using System.Collections;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefab; // ��������v���n�u
    public int maxAmount = 10; // ��������ő吔
    public float coolTime = 2.0f; // �N�[���^�C���i�b�j

    private int currentAmount = 0; // ���ݐ�������Ă��鐔

    void Start()
    {
        StartCoroutine(SpawnPrefab());
    }

    private IEnumerator SpawnPrefab()
    {
        while (currentAmount < maxAmount)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-70f, 70f),
                0.6f,
                Random.Range(-70f, 70f)
            );

            Instantiate(prefab, randomPosition, Quaternion.identity);
            currentAmount++;

            yield return new WaitForSeconds(coolTime); // �N�[���^�C����ҋ@
        }
    }
}
