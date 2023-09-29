using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform[] _spawnTransForm;
    [SerializeField] int _damage = -10;
    [SerializeField] float _fireCD = 3f;
    [SerializeField] float _bulletSpeed = 10;
    [SerializeField] float _bulletLife = 10;

    private bool _isFire = false;
    private bool _canFire = true;


    public void SetisFire(bool a)
    {
        _isFire = a;
    }


    private void Update()
    {
        // Fire1 ボタン（デフォルトは左Ctrlまたはマウス左ボタン）の入力をチェック
        if (_isFire && _canFire)
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
        foreach (Transform t in _spawnTransForm)
        {
            GameObject newBullet = Instantiate(_bullet, t);

            Bullet a = newBullet.GetComponent<Bullet>();
            a.DestoryBullet(_bulletLife);
            a.SetdamageOrHealValue(_damage);
            newBullet.transform.parent = null;
            newBullet.GetComponent<Rigidbody2D>().AddForce(newBullet.transform.up * _bulletSpeed);
        }
        // 新しい弾丸を生成する

    }
}
