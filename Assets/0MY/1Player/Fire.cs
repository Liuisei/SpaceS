using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _spawnTransForm;
    [SerializeField] int _damage = -10;
    [SerializeField] float _fireCD = 3f;
    [SerializeField] float _bulletSpeed = 10;
    [SerializeField] float _bulletLife = 10;

    private bool _canFire = true;

    private void Update()
    {
        // Fire1 �{�^���i�f�t�H���g�͍�Ctrl�܂��̓}�E�X���{�^���j�̓��͂��`�F�b�N
        if (Input.GetButton("Fire1") && _canFire)
        {
            _canFire = false;
            FireBullet();
            StartCoroutine(ResetFireCooldown());
        }
    }

    private IEnumerator ResetFireCooldown()
    {
        yield return new WaitForSeconds(_fireCD);
        _canFire = true;
    }

    private void FireBullet()
    {
        // �V�����e�ۂ𐶐�����
       GameObject newBullet =  Instantiate(_bullet, _spawnTransForm);

        Bullet a = newBullet.GetComponent<Bullet>();
        a.DestoryBullet(_bulletLife);
        a.SetdamageOrHealValue(_damage);
        newBullet.transform.parent = null;
        newBullet.GetComponent<Rigidbody2D>().AddForce(transform.up*_bulletSpeed);
    }
}
