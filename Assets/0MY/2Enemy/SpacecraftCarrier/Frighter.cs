using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frighter : MonoBehaviour
{
    [SerializeField] int frighterPower = 5;
    [SerializeField] GameObject frightBoxs;
    [SerializeField] Transform frightBoxTransform;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<NormalStar>(out NormalStar NS))
        {
            NS.StarPowerChange(frighterPower);
            Destroy(gameObject);
        }
    }
}
