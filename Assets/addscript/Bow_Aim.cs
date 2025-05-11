using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow_Aim : MonoBehaviour
{
    public Transform target;
    public Transform body;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 左クリックを検出
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 Aimpos = target.rotation.eulerAngles;
            body.rotation = Quaternion.Euler(Aimpos.x, Aimpos.y, 0);

        }
    }
}
