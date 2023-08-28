using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHP : HP
{
    SpriteRenderer spriteRenderer;

    [SerializeField] GameObject dropItem;

    public override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void FixedUpdate()
    {
        spriteRenderer.color = Color.Lerp(Color.red, Color.white, (float)GetHP()/(float)GetMaxHP() );
    }

    public override void HpUnder0()
    {
        base.HpUnder0();


        GameObject newpoint = Instantiate( dropItem , transform);
        newpoint.transform.parent = null;

        Debug.Log("drop point ");



        Destroy(gameObject);
    }
}
