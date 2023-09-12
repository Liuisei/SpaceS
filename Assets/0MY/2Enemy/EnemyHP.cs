using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : HP
{

    [SerializeField] GameObject[] _dropItems; // ドロップアイテムのプレハブ配列
    [SerializeField] SpriteRenderer _spriteRenderer;

    [SerializeField] bool doonce = true;
    public override void Start()
    {
        base.Start();
    }
    public override void HpUnder0()
    {
        base.HpUnder0();
        
        if (_dropItems.Length > 0 && doonce == true)
        {
            doonce = false;
            // ドロップアイテムの配列からランダムに選択
            GameObject selectedDropItem = _dropItems[Random.Range(0, _dropItems.Length)];

            // ドロップアイテムをインスタンス化
            if (selectedDropItem != null)
            {
                GameObject newPoint = Instantiate(selectedDropItem, transform.position, Quaternion.identity);

                // インスタンス化後、親オブジェクトを解除
                newPoint.transform.SetParent(null);

                Debug.Log("Dropped item: " + selectedDropItem.name);
            }
        }

        // 敵のゲームオブジェクトを破棄
        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        if(_spriteRenderer != null)
        {
            _spriteRenderer.color = Color.Lerp(Color.red, Color.white, (float)GetHP() / (float)GetMaxHP());
        }
    }
}
