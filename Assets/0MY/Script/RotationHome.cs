using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationHome : MonoBehaviour
{
    public float rotationSpeed = 45.0f; // ��]���x�i�x/�b�j

    // Start is called before the first frame update
    void Start()
    {
        // �����ŏ����ݒ�Ȃǂ��s���ꍇ�Ɏg�p
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // �I�u�W�F�N�g����]������
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
