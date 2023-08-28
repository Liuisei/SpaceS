using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveTo : MonoBehaviour
{
    [SerializeField] Transform _target;   
    [SerializeField] Transform _observer; 
    [SerializeField] int _range = 10;     
    [SerializeField] float _forceMagnitude = 10f;
    [SerializeField] bool _premission = false;
    private Rigidbody2D _rigidbody;

    

    private void Start()
    {
        _rigidbody = _observer.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // 敵の位置と目的地との距離を計算

        if (_premission == true && _target != null)
        {
            float distanceToTarget = Vector2.Distance(_observer.position, _target.position);

            // 距離が指定した範囲内にあるかチェック
            if (distanceToTarget <= _range)
            {

            }
            else
            {
                // 目的地に向かって力を加えるコードをここに記述
                Vector2 direction = (_target.position - _observer.position).normalized;
                _rigidbody.AddForce(direction * _forceMagnitude);
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
