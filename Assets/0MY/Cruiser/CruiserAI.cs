using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruiserAI : MonoBehaviour
{
    [SerializeField] MoveTo moveTo;
    [SerializeField] CruiserRotation cruiserRotation;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (moveTo != null && collision.TryGetComponent<PlayerMove>(out _) )
        {
            
            moveTo.SetTarget(collision.transform);
            moveTo.SetMovePremission(true);
            cruiserRotation.Settarget(collision.transform);

            Debug.Log("SET CRUISER PLAYER");

        }
        Debug.Log("CRUISER PLAYER ENTER");
    }



}
