using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LookAt : MonoBehaviour
{
    /// <summary>  見るターゲット　/// </summary>
    Vector2 _tergetV2;

    protected virtual void FixedUpdate()
    {
        transform.up = (_tergetV2 - (Vector2)transform.position).normalized;//ターゲット　の　方向を上にする
    }
    public void SetTarget(Vector2 targetV2)//ターゲット　の　セット
    {
        _tergetV2 = targetV2;
    }
}