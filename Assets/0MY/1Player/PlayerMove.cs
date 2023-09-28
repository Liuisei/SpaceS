using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1f;

    Rigidbody2D _rb2D;


    int mapRangex = 150;
    int mapRangey = 150;


    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    public void SetSpeed(int speed)
    {
        _moveSpeed = speed;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal"); // …•½•ûŒü‚Ì“ü—Í‚ğŒŸo‚·‚é
        float v = Input.GetAxisRaw("Vertical"); // ‚’¼•ûŒü‚Ì“ü—Í‚ğŒŸo‚·‚é
        _rb2D.AddForce(new Vector2(h, v) * _moveSpeed);




        if (transform.position.x < mapRangex * -1)
        {
            transform.position = new Vector3(transform.position.x * -1 - 5, transform.position.y, transform.position.z);
        }
        if (transform.position.x > mapRangex)
        {
            transform.position = new Vector3(transform.position.x * -1 + 5, transform.position.y, transform.position.z);
        }
        if (transform.position.y < mapRangey * -1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1 - 5, transform.position.z);
        }
        if (transform.position.y > mapRangey)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        }
    }
}
