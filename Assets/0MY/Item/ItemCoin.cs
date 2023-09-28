using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class ItemCoin : MonoBehaviour
{

    [SerializeField] int _lifetime = 10;
    [SerializeField] int _coinValue = 100;
    // Start is called before the first frame update
    void Start()
    {
        DestoryCoin(_lifetime);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMove>(out _))
        {
            DataManager.instance.ChangePoint(_coinValue * DataManager.instance.worldLevel);
            Debug.Log("point change");

            DestoryCoin(0);
        }
        Debug.Log("OnTriggerEnter2D(Collider2D collision)");
    }


    public void DestoryCoin(int time)
    {
        Destroy(gameObject, time);
    }
}
