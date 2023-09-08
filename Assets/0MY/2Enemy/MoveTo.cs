using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveTo : MonoBehaviour
{
    [SerializeField] Transform _target;   // �ړ��̖ڕW�ƂȂ�Transform
    [SerializeField] Transform _executer; // �ړ�����Transform
    [Range(1, 10)] [SerializeField] float _moveLine = 10;     // �ړ����n�߂�͈�
    [Range(1,  5)] [SerializeField] float _movelineRange = 2;     // �ړ����n�߂�͈�

    [SerializeField] float _speed = 10f;  // �ړ����x
    [SerializeField] bool _movePremission = false; // �ړ��������邩�ǂ����̃t���O
    private Rigidbody2D _rigidbody;

    bool cdMovetoPosition = false;
    [SerializeField] bool cruiserTogether = true;

    Vector3 _position;
    enum CuriserPosition
    {
        UP, DOWN, LEFT, RIGHT
    }

    [SerializeField] CuriserPosition _enumPosition = CuriserPosition.UP;

    private void Start()
    {
        _rigidbody = _executer.GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        if (_movePremission == true && _target != null)
        {
            float distanceToTarget = Vector2.Distance(_executer.position, _target.position );              // �G�̈ʒu�ƖړI�n�Ƃ̋������v�Z

            if (distanceToTarget <= _moveLine)                                                            // �߂����@���
            {
                Vector2 direction = -1 * (_target.position - _executer.position).normalized;

                _rigidbody.AddForce(direction * _speed);


                if (distanceToTarget <= _moveLine / 2)
                {
                    _rigidbody.velocity = new Vector2(direction.x, direction.y)*_speed/9f;
                }
            }
            else if (distanceToTarget <= _moveLine�@+ _movelineRange)                                     //�����Ȃ��^�񒆃����W
            {
//                StartCoroutine(MovetoPosition());
            }
            else                                                                                           //�͈͊O�@�߂Â�
            {

                Vector2 direction = (_target.position - _executer.position).normalized;                   // �ړI�n�ւ̃x�N�g�����v�Z���A���K���i������1�ɂȂ�j���܂��B

                _rigidbody.AddForce(direction * _speed);

                // Rigidbody2D�ɗ͂������Ĉړ������܂��B

            }

            if (cruiserTogether == true)
            {
                _executer.transform.GetComponent<Rigidbody2D>().AddForce(_target.transform.GetComponent<Rigidbody2D>().velocity);
            }
        }
    }
    IEnumerator MovetoPosition()
    {
        if (cdMovetoPosition == false)
        {
            cdMovetoPosition = true;
            yield return new WaitForSeconds(0.3f);
            switch (_enumPosition)
            {
                case CuriserPosition.UP:
                    _rigidbody.AddForce(_executer.transform.up * _speed);
                    break;
            }
            cdMovetoPosition = false;
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
