using UnityEngine;
/// <summary>
/// �}�E�X������p
/// </summary>
public class LookAtMouse : LookAt
{
    Vector2 _mousePosition;


    // �Œ�t���[�����[�g�Ń}�E�X�̈ʒu��ǐՂ��A�I�u�W�F�N�g����������

    protected override void FixedUpdate()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        SetTarget(_mousePosition);

        // ���N���X�̃��\�b�h���Ăяo��
        base.FixedUpdate();
    }
}
