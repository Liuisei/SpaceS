using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalStar : MonoBehaviour
{
    [SerializeField] int _starPower = 5;
    public void Starpower(int power)
    {
        _starPower += power;
        Debug.Log(power + "sssssssssssssssssssssssssssssssssssssssssssssss");
    }
}
