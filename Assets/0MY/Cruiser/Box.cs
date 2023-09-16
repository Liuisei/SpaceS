using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Box : MonoBehaviour
{
    [SerializeField] Sprite[] sprite2DsRight;
    [SerializeField] Sprite[] sprite2DsLeft;
    [SerializeField] bool right = true;
    [SerializeField] SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RandomSprite(bool isrite)
    {
        right = isrite;
        if (right == true)
        {
            if (Random.Range(0,1) == 0)
            {
                spriteRenderer.sprite = sprite2DsRight[Random.Range(0,sprite2DsRight.Length)];
            }
            else
            {
                spriteRenderer.sprite = sprite2DsLeft[Random.Range(0, sprite2DsLeft.Length)];
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            if (Random.Range(0, 1) == 0)
            {
                spriteRenderer.sprite = sprite2DsRight[Random.Range(0, sprite2DsRight.Length)];
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                spriteRenderer.sprite = sprite2DsLeft[Random.Range(0, sprite2DsLeft.Length)];
            }
        }

    }
}
