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



}
