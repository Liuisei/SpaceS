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
    [SerializeField] GameObject[] _transportShips;//�A���@
    [SerializeField] GameObject[] _matherShips;



    // Start is called before the first frame update
    void Start()
    {

        int a = Random.Range(0, _normalstars.Length);
        GameObject newTransShip = Instantiate(_transportShips[Random.Range(0,_transportShips.Length)], transform);
        newTransShip.GetComponent<MoveTo>().SetTarget(_normalstars[a]);
        newTransShip.GetComponent<EnemyLookPlayer>().SetTarget(_normalstars[a]);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
