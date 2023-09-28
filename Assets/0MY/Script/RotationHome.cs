using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationHome : MonoBehaviour
{
    public float rotationSpeed = 45.0f; // 回転速度（度/秒）

    // Start is called before the first frame update
    void Start()
    {
        // ここで初期設定などを行う場合に使用
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // オブジェクトを回転させる
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
