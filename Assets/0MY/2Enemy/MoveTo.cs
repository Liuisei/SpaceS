using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    [SerializeField] Transform _target;   // �ړ��̖ڕW�ƂȂ�Transform
    [SerializeField] Transform _observer; // �ړ����Ď�����Transform
    [SerializeField] int _range = 10;     // �ړ����n�߂�͈�
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
            // �G�̈ʒu�ƖړI�n�Ƃ̋������v�Z
            float distanceToTarget = Vector2.Distance(_observer.position, _target.position);

            // �������w�肵���͈͓��ɂ��邩�`�F�b�N
            if (distanceToTarget <= _range)
            {
                // �������Ȃ��i�͈͓��ɂ��邽�߁j
            }
            else
            {
                // �ړI�n�Ɍ������ė͂�������R�[�h�������ɋL�q

                // �ړI�n�ւ̃x�N�g�����v�Z���A���K���i������1�ɂȂ�j���܂��B
                Vector2 direction = (_target.position - _observer.position).normalized;

                // Rigidbody2D�ɗ͂������Ĉړ������܂��B
                _rigidbody.AddForce(direction * _speed);
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
