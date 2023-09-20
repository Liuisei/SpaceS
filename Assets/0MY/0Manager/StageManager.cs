using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance = null;
    public static GameObject playerGOBJ = null;
    [SerializeField] CinemachineVirtualCamera CinemachineVirtualCamera = null;

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

    private void Start()
    {
        playerGOBJ = Instantiate(DataManager.instance.shipDatas[DataManager.instance.homeShip].ship, transform);
        playerGOBJ.GetComponent<PlayerMove>().enabled = true;
        playerGOBJ.GetComponent<Fire>().enabled = true;
        playerGOBJ.GetComponent<LookAtMousePoint>().enabled = true;
        CinemachineVirtualCamera.m_Follow = playerGOBJ.transform;
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
        Debug.Log("playerGOBJ hp under 0");
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
