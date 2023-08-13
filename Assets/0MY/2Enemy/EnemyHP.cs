using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHP : HP
{
    SpriteRenderer spriteRenderer;

    public override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void FixedUpdate()
    {
        spriteRenderer.color = Color.Lerp(Color.red, Color.white, (float)GetHP()/(float)GetMaxHP() );
    }

}
