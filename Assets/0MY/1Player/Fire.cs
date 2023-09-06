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
        // Fire1 ボタン（デフォルトは左Ctrlまたはマウス左ボタン）の入力をチェック
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
        // 新しい弾丸を生成する
       GameObject newBullet =  Instantiate(_bullet, _spawnTransForm);

        Bullet a = newBullet.GetComponent<Bullet>();
        a.DestoryBullet(_bulletLife);
        a.SetdamageOrHealValue(_damage);
        newBullet.transform.parent = null;
        newBullet.GetComponent<Rigidbody2D>().AddForce(transform.up*_bulletSpeed);
    }
}
