using UnityEngine;
/// <summary>
/// マウスを見る用
/// </summary>
public class LookAtMouse : LookAt
{
    Vector2 _mousePosition;


    // 固定フレームレートでマウスの位置を追跡し、オブジェクトを向かせる

    protected override void FixedUpdate()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        SetTarget(_mousePosition);

        // 基底クラスのメソッドを呼び出す
        base.FixedUpdate();
    }
}
