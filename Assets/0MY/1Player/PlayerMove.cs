using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] float rotation_speed = 1f;

    Rigidbody2D _rb2D;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal"); // 水平方向の入力を検出する
        float v = Input.GetAxisRaw("Vertical"); // 垂直方向の入力を検出する
        _rb2D.AddForce(new Vector2(h, v) * _moveSpeed);
    }
}
