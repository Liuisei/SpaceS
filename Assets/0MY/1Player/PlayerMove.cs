using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{


    [SerializeField] float _speed = 10;
    Rigidbody2D _rb2D;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal"); // ���������̓��͂����o����
        float v = Input.GetAxisRaw("Vertical"); // ���������̓��͂����o����
        // ���͂ɉ����ăp�h���𐅕������ɓ�����
        Vector2 velocity = new Vector2(h, v) * _speed;
        _rb2D.AddForce(velocity);
    }

}
