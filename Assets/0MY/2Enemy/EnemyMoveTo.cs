using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveTo : MonoBehaviour
{
    [SerializeField] Transform _target;   
    [SerializeField] Transform _observer; 
    [SerializeField] int _range = 10;     
    [SerializeField] float _speed = 10f;
    [SerializeField] bool _premission = false;
    private Rigidbody2D _rigidbody;

    

    private void Start()
    {
        _rigidbody = _observer.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // �G�̈ʒu�ƖړI�n�Ƃ̋������v�Z

        if (_premission == true && _target != null)
        {
            float distanceToTarget = Vector2.Distance(_observer.position, _target.position);

            // �������w�肵���͈͓��ɂ��邩�`�F�b�N
            if (distanceToTarget <= _range)
            {

            }
            else
            {
                // �ړI�n�Ɍ������ė͂�������R�[�h�������ɋL�q
                Vector2 direction = (_target.position - _observer.position).normalized;
                _rigidbody.AddForce(direction * _speed);
            }
        }
    }
    public void SetPremission(bool premisson)
    {
        _premission = premisson;
    }
    public void SetTarget(Transform transform)
    {
        _target = transform;
    }


}
