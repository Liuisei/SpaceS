using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacecraftCarrier : MonoBehaviour
{
    [SerializeField] int _carrierPower = 10;
    [SerializeField] int _starPoint = 10;
    [SerializeField] float _carrierAttackSpeed = 10;
    [SerializeField] GameObject[] _spaceShipTipe;
    [SerializeField] GameObject[] _nowAttackers;

    [SerializeField] Transform _spawnTransform;
    [SerializeField] Transform _backTransform;

    [SerializeField] bool _attack = false;

    private void Start()
    {
        _carrierPower *= DataManager.instance.worldLevel;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<PlayerMove>(out _))
        {
            _attack = true;
            StartCoroutine(SpawnSpaceShip());
        }

        if (collision.transform.TryGetComponent<NormalStar>(out NormalStar NS))
        {
            NS.StarPowerChange(_starPoint);
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<PlayerMove>(out _))
        {
            _attack = false;
        }

    }

    IEnumerator SpawnSpaceShip()
    {
        if ( _attack == true)
        {
            SpawnShip();
             yield return new WaitForSeconds(_carrierAttackSpeed);
            StartCoroutine(SpawnSpaceShip());
        }
    }

    void SpawnShip()
    {
        if(_carrierPower > 0)
        {
            _carrierPower--;
            Instantiate(_spaceShipTipe[Random.Range(0, _spaceShipTipe.Length)], _spawnTransform);
        }
    }

}
