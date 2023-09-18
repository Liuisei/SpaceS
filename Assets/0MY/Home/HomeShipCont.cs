using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeShipCont : MonoBehaviour
{
    [SerializeField] GameObject NowOBJ = default;
    [SerializeField] GameObject buyBotton;
    [SerializeField] GameObject playBotton;
    // Start is called before the first frame update
    void Start()
    {
        SpawnShip();
    }

    public void ChangeShip(bool i)
    {
        if (i == true)
        {
            Destroy(NowOBJ);
            DataManager.instance.homeShip++;
            if (DataManager.instance.homeShip > DataManager.instance.shipDatas.Count - 1)
            {
                DataManager.instance.homeShip = 0;
            }
            SpawnShip();
  
        }
        else
        {
            Destroy(NowOBJ);
            DataManager.instance.homeShip--;
            if (DataManager.instance.homeShip < 0)
            {
                DataManager.instance.homeShip = DataManager.instance.shipDatas.Count -1;
            }
            SpawnShip();

        }
    }

    void SpawnShip()
    {
        NowOBJ = Instantiate(DataManager.instance.shipDatas[DataManager.instance.homeShip].ship, transform);

        if (DataManager.instance.shipDatas[DataManager.instance.homeShip].shipBuy == false)
        {
            buyBotton.SetActive(true);
            playBotton.SetActive(false);
        }
        else
        {
            buyBotton.SetActive(false);
            playBotton.SetActive(true);
        }

        Debug.Log(DataManager.instance.homeShip);
    }

    public void BuyShip()
    {
        if (DataManager.instance.shipDatas[DataManager.instance.homeShip].shipBuy == false)
        {
            if(DataManager.instance.shipDatas[DataManager.instance.homeShip].shipCost <= DataManager.instance.GetPoint())
            {
                DataManager.instance.ChangePoint(DataManager.instance.shipDatas[DataManager.instance.homeShip].shipCost * -1);
                DataManager.instance.shipDatas[DataManager.instance.homeShip].shipBuy = true;
                Destroy(NowOBJ);
                SpawnShip();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
