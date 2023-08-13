using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] int _damageOrHeal = -1; // ダメージまたは回復量

    public void SetdamageOrHealValue(int damageOrHealValue)
    {
        _damageOrHeal = damageOrHealValue;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<HP>(out HP hp))//out HP hp (null chack)
        {
            hp.ChangeHP(_damageOrHeal); // 取得したHPスクリプトのChangeHP関数を呼び出す
            DestoryBullet(0);
            Debug.Log("hp");
        }
        Debug.Log("hit");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<HP>(out HP hp))
        {
            hp.ChangeHP(_damageOrHeal); // 取得したHPスクリプトのChangeHP関数を呼び出す
            Debug.Log("hpb");

        }
        Debug.Log("hitb");
    }


    public void DestoryBullet(float destorytime)
    {
        Destroy(gameObject, destorytime);
    }
}