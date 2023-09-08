using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruiserRotation : MonoBehaviour
{
    [SerializeField] Transform _transformTarget;
    [SerializeField] Transform _executor;

    private void FixedUpdate()
    {
        if (_executor != null && _transformTarget != null)
        {
            _executor.rotation = _transformTarget.rotation;
        }
    }
    public void SetExecutor(Transform transform)
    {
        _executor = transform;
    }
    public void Settarget(Transform transform)
    {
        _transformTarget = transform;
    }
}
