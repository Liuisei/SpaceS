using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruiserAI : MonoBehaviour
{
    [SerializeField] MoveTo moveTo;
    [SerializeField] CruiserRotation cruiserRotation;


    private void Start()
    {


        moveTo.SetTarget(StageManager.instance.playerGOBJ.transform);
        moveTo.SetMovePremission(true);

        Debug.Log("SET CRUISER PLAYER");


    }




}
