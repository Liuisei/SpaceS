using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LookAt : MonoBehaviour
{
    /// <summary>  ����^�[�Q�b�g�@/// </summary>
    Vector2 _tergetV2;

    protected virtual void FixedUpdate()
    {
        transform.up = (_tergetV2 - (Vector2)transform.position).normalized;//�^�[�Q�b�g�@�́@��������ɂ���
    }
    public void SetTarget(Vector2 targetV2)//�^�[�Q�b�g�@�́@�Z�b�g
    {
        _tergetV2 = targetV2;
    }
}