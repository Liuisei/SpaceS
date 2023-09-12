using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalStar : MonoBehaviour
{
    [SerializeField] int _starPower = 5;
    public void StarPowerChange(int power)
    {
        _starPower += power;
        Debug.Log(_starPower + "StarPower");
    }
}
