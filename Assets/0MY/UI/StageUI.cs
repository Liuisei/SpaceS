using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _hp;
    [SerializeField] Slider _hpSlider;
    [SerializeField] TextMeshProUGUI _point;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (StageManager.instance != null )
        {
           
            _hpSlider.value =  (float)StageManager.instance.GetHP() /(float)StageManager.instance.GetMaxHP();

            _hp.SetText(StageManager.instance.GetHP() + "/" + StageManager.instance.GetMaxHP());

            _point.SetText("COIN:"+DataManager.instance.GetPoint());
        }
    }
}
