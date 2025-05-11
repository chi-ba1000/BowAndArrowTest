using System.Collections;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefab; // 生成するプレハブ
    public int maxAmount = 10; // 生成する最大数
    public float coolTime = 2.0f; // クールタイム（秒）

    private int currentAmount = 0; // 現在生成されている数

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

            yield return new WaitForSeconds(coolTime); // クールタイムを待機
        }
    }
}
