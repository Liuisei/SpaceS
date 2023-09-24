using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager instance = null;
    public int homeShip = 0;

    public int worldLevel = 1;

    public GameObject moveui;
    [SerializeField] int _point = 1000;


    public List<ShipData> shipDatas = new List<ShipData>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
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
        // コルーチンを開始
        StartCoroutine(LoadSceneWithDelay(i));
    }

    private IEnumerator LoadSceneWithDelay(int i)
    {
        // moveuiをインスタンス化（表示）
        Instantiate(moveui);

        // 2秒待機
        yield return new WaitForSeconds(2f);

        // シーンをロード
        SceneManager.LoadScene(i);
    }
}