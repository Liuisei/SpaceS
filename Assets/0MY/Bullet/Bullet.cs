using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] int _damageOrHeal = -1; // ダメージまたは回復量

    [SerializeField] bool _razer = false;

    [SerializeField] GameObject _fireFX;

    [SerializeField] GameObject _fireend;

    private void Start()
    {
        Instantiate(_fireFX,transform.position,transform.rotation);
    }
    public void SetdamageOrHealValue(int damageOrHealValue)
    {
        _damageOrHeal = damageOrHealValue;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_razer)
        {
            if (collision.gameObject.TryGetComponent<HP>(out HP hp))//out HP hp (null chack)
            {
                hp.ChangeHP(_damageOrHeal); // 取得したHPスクリプトのChangeHP関数を呼び出す
                DestoryBullet(0);
                Instantiate(_fireend, transform.position, transform.rotation);

                Debug.Log("hp");
            }
            else if (collision.gameObject.TryGetComponent<PlayerMove>(out _))
            {
                StageManager.instance.ChangeHP(_damageOrHeal);
                DestoryBullet(0);
                Instantiate(_fireend, transform.position, transform.rotation);


            }
            Debug.Log("hit");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_razer)
        {
            if (collision.gameObject.TryGetComponent<HP>(out HP hp))
            {
                hp.ChangeHP(_damageOrHeal); // 取得したHPスクリプトのChangeHP関数を呼び出す
                Instantiate(_fireend, transform.position, transform.rotation);

                Debug.Log("hpb");
            }
            Debug.Log("hitb");
        }
    }


    public void DestoryBullet(float destorytime)
    {
        Destroy(gameObject, destorytime);
    }

 
}