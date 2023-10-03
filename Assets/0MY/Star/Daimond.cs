using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Daimond : MonoBehaviour
{
    [SerializeField] Collider2D collider2;

    // Start is called before the first frame update
    void Start()
    {
        DataManager.instance.ChangePoint(1000 * DataManager.instance.worldLevel);
        DataManager.instance.worldLevel++;

        Invoke("Move", 5.1f);
    }

    void Move()
    {
        DataManager.instance.GameScene(0);
    }

    private void FixedUpdate()
    {
        // collider2��CircleCollider2D�ł��邱�Ƃ��m�F
        CircleCollider2D circleCollider = collider2 as CircleCollider2D;

        if (circleCollider != null)
        {
            // ���a���L����
            circleCollider.radius += 0.5f;
        }
    }
}
