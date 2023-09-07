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
        _rb2D.AddForce(transform.up * _moveSpeed * Input.GetAxisRaw("Vertical"));

        _rb2D.AddTorque(-1 * rotation_speed * Input.GetAxisRaw("Horizontal"));

    }
}
