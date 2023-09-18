using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HomeUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI _point;
    [SerializeField] TextMeshProUGUI _shipCost;


    private void FixedUpdate()
    {
        if (DataManager.instance != null)
        {
            _point.SetText("COIN:" + DataManager.instance.GetPoint());
            _shipCost.SetText("$:" + DataManager.instance.shipDatas[DataManager.instance.homeShip].shipCost);
        }
    }
}
