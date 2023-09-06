using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    [SerializeField] Transform _target;   // 移動の目標となるTransform
    [SerializeField] Transform _observer; // 移動を監視するTransform
    [Range(1,10)] [SerializeField] float _range = 10;     // 移動を始める範囲
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
            // 敵の位置と目的地との距離を計算
            float distanceToTarget = Vector2.Distance(_observer.position, _target.position);

            // 距離が指定した範囲内にあるかチェック
            if (distanceToTarget <= _range)
            {
                Vector2 direction = -1 * (_target.position - _observer.position).normalized;

                // Rigidbody2Dに力を加えて移動させます。
                _rigidbody.AddForce(direction * _speed);
            }
            else
            {
                // 目的地に向かって力を加えるコードをここに記述

                // 目的地へのベクトルを計算し、正規化（長さが1になる）します。
                Vector2 direction = (_target.position - _observer.position).normalized;

                // Rigidbody2Dに力を加えて移動させます。
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
