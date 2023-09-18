using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] int _starPower = 10;
    [SerializeField] int _MaxStarPower = 100;
    [SerializeField] int _starPowerPluseSpeed = 60;
    [SerializeField] int _starPowerPluseValue = 1;
    [SerializeField] bool _PlusePowerOKorNO = true;
    [SerializeField] Transform[] _normalstars;

    [SerializeField] GameObject[] _transportShips;//—A‘—‹@
    [SerializeField] int _transportCD = 3;
    [SerializeField] GameObject[] _matherShips;
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
    public void Spawn()
    {
        if (_starPower > 0)
        {
            _starPower -= 1;

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
}
