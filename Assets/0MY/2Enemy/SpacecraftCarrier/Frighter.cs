using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Frighter : MonoBehaviour
{
    [SerializeField] int frighterPower = 5;
    [SerializeField] GameObject[] frightBoxs;
    [SerializeField] Transform[] frightBoxTransforms;
    [SerializeField] List<GameObject> takeBoxs;
    

    private void Start()
    {
        frighterPower = frighterPower * DataManager.instance.worldLevel ;
        SetBox();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.transform.TryGetComponent<NormalStar>(out NormalStar NS))
        {
            NS.StarPowerChange(frighterPower);
            Destroy(gameObject);
        }
    }
    public void SetBox()
    {
        int i = 0;
        foreach (var transform in frightBoxTransforms)
        {
            GameObject newBox = Instantiate(frightBoxs[i], transform);
            takeBoxs.Add(newBox);
            newBox.GetComponent<Box>().RandomSprite(transform.localPosition.x > 0);
            newBox.transform.parent = this.transform;
            newBox.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }

    public void DropBox()
    {
        foreach (var box in takeBoxs)
        {
            box.transform.parent = null;
            box.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            box.GetComponent<Collider2D>().enabled = true;
        }
    }
}
