using UnityEngine;
/// <summary>
/// マウスを見る用
/// </summary>
public class LookAtMousePoint : LookAt
{
    private void Start()
    {
         SetTarget(MousePointer.instance.transform);
    }
    // 固定フレームレートでマウスの位置を追跡し、オブジェクトを向かせる

}
