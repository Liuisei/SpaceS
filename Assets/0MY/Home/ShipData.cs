using UnityEngine;

[System.Serializable]
public class ShipData
{
    public GameObject ship;
    public string shipName;
    public bool shipBuy;
    public int shipCost;
    public int speed;
    public int hp;
    public int fireSpeed;
    public int fireDamage;
    public int lvBuy;

    [Range(1, 10)] public int speedLv, hpLv, firespeedLv, fireDamageLv;
}
