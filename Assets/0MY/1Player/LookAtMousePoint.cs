using UnityEngine;
/// <summary>
/// �}�E�X������p
/// </summary>
public class LookAtMousePoint : LookAt
{
    private void Start()
    {
         SetTarget(MousePointer.instance.transform);
    }
    // �Œ�t���[�����[�g�Ń}�E�X�̈ʒu��ǐՂ��A�I�u�W�F�N�g����������

}
