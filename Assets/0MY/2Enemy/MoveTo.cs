using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    [SerializeField] Transform _target;   // 移動の目標となるTransform
    [SerializeField] Transform _observer; // 移動するTransform
    [Range(1, 10)] [SerializeField] float _moveLine = 10;     // 移動を始める範囲
    [Range(1,  5)] [SerializeField] float _movelineRange = 2;     // 移動を始める範囲

    [SerializeField] float _speed = 10f;  // 移動速度
    [SerializeField] bool _movePremission = false; // 移動を許可するかどうかのフラグ
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = _observer.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_movePremission == true && _target != null)
        {
            float distanceToTarget = Vector2.Distance(_observer.position, _target.position);              // 敵の位置と目的地との距離を計算

            if (distanceToTarget <= _moveLine)                                                            // 近すぎ　後退
            {
                Vector2 direction = -1 * (_target.position - _observer.position).normalized;

                _rigidbody.AddForce(direction * _speed);
            }
            else if (distanceToTarget <= _moveLine　+ _movelineRange)                                     //動かない真ん中レンジ
            {

            }
            else                                                                                           //範囲外　近づく
            {

                Vector2 direction = (_target.position - _observer.position).normalized;                   // 目的地へのベクトルを計算し、正規化（長さが1になる）します。

                _rigidbody.AddForce(direction * _speed);                                                  // Rigidbody2Dに力を加えて移動させます。

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
