using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }



    [SerializeField] int _playerHP = 100;
    [SerializeField] int _playerMaxHP = 100;
    [SerializeField] int _point = 1000;

    public void ChangeHP(int damageOrHeal)
    {
        _playerHP += damageOrHeal;

        if (_playerHP <= 0)
        {
            HPunder0();
        }
        if (_playerHP >= _playerMaxHP)
        {
            HPOverMax();
        }

    }

    public void ChangePoint(int value)
    {


        if (_point + value <= 0)
        {
            PointCantBuy();
        }
        else if (_point > 100000000)
        {
            PointMax();
        }
        else
        {
            _point += value;
        }
    }

    private void PointCantBuy()
    {
        Debug.Log("player hp under 0");
    }

    private void PointMax()
    {
        Debug.Log("point over max");
    }
    private void HPunder0()
    {
        Debug.Log("player hp under 0");
    }

    private void HPOverMax()
    {
        Debug.Log("over max");
    }


    public int GetHP()
    {
        return _playerHP;
    }

    public int GetMaxHP()
    {
        return _playerMaxHP;
    }

    public int GetPoint()
    {
        return _point;
    }

}
