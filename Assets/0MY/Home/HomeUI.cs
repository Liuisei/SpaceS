using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI _point;
    [SerializeField] TextMeshProUGUI _shipCost;
    [SerializeField] TextMeshProUGUI _shipName;
    [SerializeField] TextMeshProUGUI _shipHpLv;
    [SerializeField] TextMeshProUGUI _shipSpeedLv;
    [SerializeField] TextMeshProUGUI _shipFireSpeedLv;
    [SerializeField] TextMeshProUGUI _shipFireDamageLV;
    [SerializeField] TextMeshProUGUI _shipHpL;
    [SerializeField] TextMeshProUGUI _shipSpeedL;
    [SerializeField] TextMeshProUGUI _shipFireSpeedL;
    [SerializeField] TextMeshProUGUI _shipFireDamageL;
    [SerializeField] TextMeshProUGUI _woldLevel;


    [SerializeField] Slider _sliderHP;
    [SerializeField] Slider _sliderSpeed;
    [SerializeField] Slider _sliderFireSpeed;
    [SerializeField] Slider _sliderFireDamage;
    [SerializeField] GameObject _gameObjectUIstart;


    private void Start()
    {
        Invoke("Startui",1);
    }

    private void Startui()
    {
        _gameObjectUIstart.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (DataManager.instance != null)
        {
            _point.SetText("COIN:" + DataManager.instance.GetPoint().ToString("000000000"));
            var data = DataManager.instance.shipDatas[DataManager.instance.homeShip];
            _shipCost.SetText("$:" + data.shipCost);
            _shipSpeedLv.SetText("Upgrade\n" + data.speedLv * data.lvBuy); //speed
            _shipHpLv.SetText("Upgrade\n" + data.hpLv * data.lvBuy); //hp
            _shipFireSpeedLv.SetText("Upgrade\n" + data.firespeedLv * data.lvBuy); //firespeedd
            _shipFireDamageLV.SetText("Upgrade\n" + data.fireDamageLv * data.lvBuy);//damage

            _shipName.SetText(data.shipName);


            _shipSpeedL.SetText("Speed Lv:" + data.speedLv); //speed
            _shipHpL.SetText("HP Lv:" + data.hpLv); //hp
            _shipFireSpeedL.SetText("FireSpeed Lv:" + data.firespeedLv); //firespeedd
            _shipFireDamageL.SetText("Damage Lv:" + data.fireDamageLv);//damage

            _sliderHP.value = ((float)data.hp + (float)data.hp * data.hpLv /10 )/ 1000;
            _sliderSpeed.value = ((float)data.speed +(float)data.speed * data.speedLv /10)/ 100;
            _sliderFireSpeed.value = ((float)data.fireSpeed + (float)data.fireSpeed * data.firespeedLv / 10) / 100;
            _sliderFireDamage.value = ((float)data.fireDamage + (float)data.fireDamage * data.fireDamageLv / 10) / 100;

            _woldLevel.SetText("World LV:" + DataManager.instance.worldLevel) ;

        }
    }

    public void BuyLvspeed()
    {
        SoundManager.Instance.PlaySE(SESoundData.SE.botton);

        var data = DataManager.instance.shipDatas[DataManager.instance.homeShip];

        if (data.speedLv * data.lvBuy <= DataManager.instance.GetPoint())
        {
            data.speedLv++;
            DataManager.instance.ChangePoint(data.speedLv * data.lvBuy * -1);
        }

    }
    public void BuyLvhp()
    {
        SoundManager.Instance.PlaySE(SESoundData.SE.botton);

        var data = DataManager.instance.shipDatas[DataManager.instance.homeShip];

        if (data.hpLv * data.lvBuy <= DataManager.instance.GetPoint())
        {
            data.hpLv++;
            DataManager.instance.ChangePoint(data.speedLv * data.lvBuy * -1);
        }

    }
    public void BuyLvfirespeed()
    {
        SoundManager.Instance.PlaySE(SESoundData.SE.botton);

        var data = DataManager.instance.shipDatas[DataManager.instance.homeShip];

        if (data.firespeedLv * data.lvBuy <= DataManager.instance.GetPoint())
        {
            data.firespeedLv++;
            DataManager.instance.ChangePoint(data.speedLv * data.lvBuy * -1);
        }

    }
    public void BuyLvfirepower()
    {
        SoundManager.Instance.PlaySE(SESoundData.SE.botton);

        var data = DataManager.instance.shipDatas[DataManager.instance.homeShip];

        if (data.fireDamageLv * data.lvBuy <= DataManager.instance.GetPoint())
        {
            data.fireDamageLv++;
            DataManager.instance.ChangePoint(data.speedLv * data.lvBuy * -1);
        }

    }
    public void Scene(int i)
    {
        SoundManager.Instance.PlaySE(SESoundData.SE.botton);

        DataManager.instance.GameScene(i);
    }
}
