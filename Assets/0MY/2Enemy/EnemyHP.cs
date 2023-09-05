using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : HP
{

    [SerializeField] GameObject[] _dropItems; // �h���b�v�A�C�e���̃v���n�u�z��
    [SerializeField] SpriteRenderer _spriteRenderer;
    public override void Start()
    {
        base.Start();
    }
    public override void HpUnder0()
    {
        base.HpUnder0();

        if (_dropItems.Length > 0)
        {
            // �h���b�v�A�C�e���̔z�񂩂烉���_���ɑI��
            GameObject selectedDropItem = _dropItems[Random.Range(0, _dropItems.Length)];

            // �h���b�v�A�C�e�����C���X�^���X��
            if (selectedDropItem != null)
            {
                GameObject newPoint = Instantiate(selectedDropItem, transform.position, Quaternion.identity);

                // �C���X�^���X����A�e�I�u�W�F�N�g������
                newPoint.transform.SetParent(null);

                Debug.Log("Dropped item: " + selectedDropItem.name);
            }
        }

        // �G�̃Q�[���I�u�W�F�N�g��j��
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
