using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LookAt : MonoBehaviour
{
    /// <summary>  ����^�[�Q�b�g�@/// </summary>
    [SerializeField] Transform _tergetTransform;
    /// <summary>  ���鑤�@/// </summary>
    [SerializeField] Transform _observer;

    [SerializeField] bool _permission = false;

    protected virtual void FixedUpdate()
    {
        if (_permission == true)
        {
            _observer.transform.up = (_tergetTransform.position - transform.position).normalized;//�^�[�Q�b�g�@�́@��������ɂ���
        }
    }

    public void SetTarget(Transform targetTransform)//�^�[�Q�b�g�@�́@�Z�b�g
    {
        _tergetTransform = targetTransform;
    }

    public void SetPremission(bool permission)//����
    {
        _permission = permission;
    }

    public void SetObserver (Transform newObserver)//���鑤
    {
        _observer = newObserver;
    }
}