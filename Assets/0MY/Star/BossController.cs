using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] int _starPower = 10;
    [SerializeField] int _starPowerPluseSpeed = 60;
    [SerializeField] int _starPowerPluseValue = 1;
    [SerializeField] bool _PlusePowerOKorNO = true;
    [SerializeField] Transform[] _normalstars;

    [SerializeField] GameObject[] _transportShips;//—A‘—‹@
    [SerializeField] int _transportCD = 3;
    [SerializeField] GameObject[] _matherShips;
    private bool _attack;
    private float _carrierAttackSpeed = 2;


    [SerializeField] GameObject[] starEnemys;
    [SerializeField] Transform[] starEnemysTransform;

    [SerializeField] SpriteRenderer spriteRenderer;
    void Start()
    {
        StartCoroutine(TransportCD());
    }
    IEnumerator TransportCD()
    {
        yield return new WaitForSeconds(_transportCD);
        Debug.Log(_starPower);
        Spawn();
    }

    public void RedCord()
    {
    
    }
    public void Spawn()
    {
        if (_starPower > 0)
        {
            int rundonStar = Random.Range(0, _normalstars.Length);

            switch (Random.Range(0, 2))
            {
                case 0:
                    SpawnFrither(rundonStar);
                    break;
                case 1:
                    SpawnMother(rundonStar);
                    break;
            }

            StartCoroutine(TransportCD());
        }
        else
        {
            StartCoroutine(TransportCD());
        }

    }
    void SpawnFrither(int tergetStar)
    {
        GameObject newTransShip = Instantiate(_transportShips[Random.Range(0, _transportShips.Length)], transform);
        newTransShip.GetComponent<MoveTo>().SetTarget(_normalstars[tergetStar]);
        newTransShip.GetComponent<EnemyLookPlayer>().SetTarget(_normalstars[tergetStar]);
    }
    void SpawnMother(int tergetStar)
    {
        GameObject newMother = Instantiate(_matherShips[Random.Range(0, _matherShips.Length)], transform);
        newMother.GetComponent<MoveTo>().SetTarget(_normalstars[tergetStar]);
        newMother.GetComponent<EnemyLookPlayer>().SetTarget(_normalstars[tergetStar]);
    }
    private Coroutine redlineCoroutine;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.TryGetComponent<PlayerMove>(out _))
        {
            _attack = true;
            StartCoroutine(SpawnSpaceShip());
            spriteRenderer.color = Color.red;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<PlayerMove>(out _))
        {
            _attack = false;
            spriteRenderer.color = Color.white;

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

    void SpawnShip()
    {
        if (_starPower > 0)
        {
            Instantiate(starEnemys[Random.Range(0, starEnemys.Length)], starEnemysTransform[Random.Range(0, starEnemysTransform.Length)]);
            foreach (var item in _normalstars)
            {
                item.GetComponent<NormalStar>().SpawnShip();
            }
        }
    }

    
}
