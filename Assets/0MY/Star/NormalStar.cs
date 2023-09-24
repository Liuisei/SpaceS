using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalStar : MonoBehaviour
{
    [SerializeField] int _starPower = 10;

    [SerializeField] int _maxStarPower = 10;

    [SerializeField] GameObject[] starEnemys;

    [SerializeField] Transform[] starEnemysTransform;
    private bool _attack;
    [SerializeField] private float _carrierAttackSpeed = 0.2f;

    public void StarPowerChange(int power)
    {
        _starPower += power;
        Debug.Log(_starPower + "StarPower");
    }

    public void Spawn()
    {
        _starPower--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<PlayerMove>(out _))
        {
            _attack = true;
            StartCoroutine(SpawnSpaceShip());
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
        if (_attack == true)
        {
            SpawnShip();
            yield return new WaitForSeconds(_carrierAttackSpeed);
            StartCoroutine(SpawnSpaceShip());
        }
    }

    public void SpawnShip()
    {
        if (_starPower > 0)
        {
            _starPower--;
            GameObject enemy = Instantiate(starEnemys[Random.Range(0, starEnemys.Length)], starEnemysTransform[Random.Range(0,starEnemysTransform.Length)]);
            enemy.GetComponentInChildren<MoveTo>().SetTarget(StageManager.instance.playerGOBJ.transform);
            enemy.GetComponentInChildren<MoveTo>().SetMovePremission(true);
        }
    }
}
