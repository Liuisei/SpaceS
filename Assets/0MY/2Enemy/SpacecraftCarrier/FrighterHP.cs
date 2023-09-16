using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrighterHP : HP
{
    [SerializeField] Frighter frighter;
    public override void HpUnder0()
    {
        base.HpUnder0();
        frighter.DropBox();
        Destroy(gameObject);
    }
}
