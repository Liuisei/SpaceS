using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class HP : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hpText;        // HP表示用のUIテキスト
    [SerializeField] Slider sliderHP;               // HPslider
    [SerializeField] int maxHP = 10;　              // 最大HP
    [SerializeField] int hp = 10;                   // 今のHP
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] bool colorChange = true;

    /// <summary>         変数         </summary>///
    public virtual void Start()
    {
        UpdateHPText(); // 初期値のHP表示を更新する
    }
    public void FixedUpdate()
    {
        if (spriteRenderer != null && colorChange == true)
        {
            spriteRenderer.color = Color.Lerp(Color.red, Color.white, (float)GetHP() / (float)GetMaxHP());
        }
    }
    public void ChangeHP(int damageOrHeal)
    {
        hp += damageOrHeal;

        if (hp <= 0)
        {
            HpUnder0();
        }
        if (hp >= maxHP)
        {
            HpOverMax();
        }

        UpdateHPText(); // HP表示を更新する
    }
    public void UpdateHPText()
    {
        if (sliderHP)
        {
            sliderHP.value = (float)hp / (float)maxHP; // HPの割合を計算する
        }
        if (hpText)
        {
            hpText.text = "HP: " + hp.ToString(); // HPの表示を更新する
        }
    }
    public virtual void HpUnder0()
    {
        Debug.Log("Die" + this);
    }
    public virtual void HpOverMax()
    {
        hp = maxHP;
    }
    public int GetHP()
    {
        return hp;
    }
    public int GetMaxHP()
    {
        return maxHP;
    }

    public void SetHP(int value)
    {
        hp = value;
        maxHP = value;
    }
}