using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform[] _spawnTransForms;
    [SerializeField] int _damage = -10;
    [Range(0.1f , 5)] [SerializeField] float _fireCD = 3f;
    float _damageTime = 30;
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
    public void SetSpeed(int lv)
    {
        _fireCD = _damageTime  /(3f * lv);
    }

    public void SetDamege(int damege)
    {
        _damage = damege;
    }

    private IEnumerator ResetFireCooldown()
    {
        yield return new WaitForSeconds(_fireCD);
        _canFire = true;
    }

    private void FireBullet()
    {
        // �V�����e�ۂ𐶐�����
        foreach (var _spawnTransForm in _spawnTransForms)
        {
            GameObject newBullet = Instantiate(_bullet, _spawnTransForm);

            Bullet a = newBullet.GetComponent<Bullet>();
            a.DestoryBullet(_bulletLife);
            a.SetdamageOrHealValue(_damage);
            newBullet.transform.parent = null;

            Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();

            // �v���C���[�̑��x���擾���āA�����e�ۂɉ�����
            bulletRigidbody.AddForce((Vector2)a.transform.up * _bulletSpeed + GetComponent<Rigidbody2D>().velocity);
        }
    }
}