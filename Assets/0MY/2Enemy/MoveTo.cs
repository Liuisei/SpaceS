using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    [SerializeField] Transform _target;   // �ړ��̖ڕW�ƂȂ�Transform
    [SerializeField] Transform _observer; // �ړ�����Transform
    [Range(1, 10)] [SerializeField] float _moveLine = 10;     // �ړ����n�߂�͈�
    [Range(1,  5)] [SerializeField] float _movelineRange = 2;     // �ړ����n�߂�͈�

    [SerializeField] float _speed = 10f;  // �ړ����x
    [SerializeField] bool _movePremission = false; // �ړ��������邩�ǂ����̃t���O
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = _observer.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_movePremission == true && _target != null)
        {
            float distanceToTarget = Vector2.Distance(_observer.position, _target.position);              // �G�̈ʒu�ƖړI�n�Ƃ̋������v�Z

            if (distanceToTarget <= _moveLine)                                                            // �߂����@���
            {
                Vector2 direction = -1 * (_target.position - _observer.position).normalized;

                _rigidbody.AddForce(direction * _speed);
            }
            else if (distanceToTarget <= _moveLine�@+ _movelineRange)                                     //�����Ȃ��^�񒆃����W
            {

            }
            else                                                                                           //�͈͊O�@�߂Â�
            {

                Vector2 direction = (_target.position - _observer.position).normalized;                   // �ړI�n�ւ̃x�N�g�����v�Z���A���K���i������1�ɂȂ�j���܂��B

                _rigidbody.AddForce(direction * _speed);                                                  // Rigidbody2D�ɗ͂������Ĉړ������܂��B

            }
        }
    }

    public void SetMovePremission(bool premisson)
    {
        _movePremission = premisson;
    }

    public void SetTarget(Transform transform)
    {
        _target = transform;
    }
}
