using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager instance = null;
    public int homeShip = 0;


    [SerializeField] int _point = 1000;


    public List<ShipData> shipDatas = new List<ShipData>();

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


    public void ChangePoint(int value)
    {


        if (_point + value < 0)
        {
            PointCantBuy();
        }
        else if (_point > 100000000)
        {
            PointMax();
            _point = 100000000;
        }
        else
        {
            _point += value;
        }
    }

    public int GetPoint()
    {
        return _point;
    }

    private void PointCantBuy()
    {
        Debug.Log("playerGOBJ hp under 0");
    }

    private void PointMax()
    {
        Debug.Log("point over max");
    }

    public void GameScene(int i)
    {
        SceneManager.LoadScene(i);
    }
}