using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager instance = null;
    public  GameObject playerGOBJ = null;
    [SerializeField] CinemachineVirtualCamera CinemachineVirtualCamera = null;

    [SerializeField] int _playerHP = 100;
    [SerializeField] int _playerMaxHP = 100;
    [SerializeField] GameObject _effectPlayerDestory;
    [SerializeField] GameObject _endui;

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
        var a = DataManager.instance.shipDatas[DataManager.instance.homeShip];
        playerGOBJ = Instantiate(a.ship, transform);
        playerGOBJ.GetComponent<PlayerMove>().enabled = true;
        playerGOBJ.GetComponent<PlayerMove>().SetSpeed(a.speed + a.speed * a.speedLv /10 );  
        playerGOBJ.GetComponent<Fire>().enabled = true;
        playerGOBJ.GetComponent<Fire>().SetDamege((a.fireDamage + a.fireDamage * a.fireDamageLv /10)*-1);
        playerGOBJ.GetComponent<Fire>().SetSpeed(a.fireSpeed + a.firespeedLv * a.fireSpeed / 10);

        playerGOBJ.GetComponent<LookAtMousePoint>().enabled = true;
        CinemachineVirtualCamera.m_Follow = playerGOBJ.transform;

        _playerMaxHP = a.hp + a.hpLv * a.hp /10;
        _playerHP =  _playerMaxHP;
        
    }




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

        Instantiate(_effectPlayerDestory, playerGOBJ.transform.position, playerGOBJ.transform.rotation);
        _endui.SetActive(true);
        playerGOBJ.SetActive(false);
        Invoke("MoveHome",1.5f);
    }

    private void MoveHome()
    {
        SceneManager.LoadScene(0);
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
