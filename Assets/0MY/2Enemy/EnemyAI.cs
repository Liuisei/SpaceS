using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] EnemyLookPlayer enemyLookPlayer;
    [SerializeField] MoveTo enemyMoveTo;
    [SerializeField] EnemyAttack enemyAttack;


    Transform _terget;

    Collider2D _tergetCollider;
    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMove>(out _))
        {
            _tergetCollider = collision;


            enemyLookPlayer.SetTarget(collision.transform);

            enemyLookPlayer.SetPremission(true);



            enemyMoveTo.SetTarget(collision.transform);

            enemyMoveTo.SetMovePremission(true);

            enemyAttack.SetisFire(true);


            Debug.Log("AI csrch in");
        }
    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_tergetCollider == collision)
        {
            enemyLookPlayer.SetPremission(false);
            Debug.Log("AI csrch leave");
            enemyAttack.SetisFire(false);
            enemyMoveTo.SetMovePremission(false);


        }
    }
    


    void Fire()
    {
        Debug.Log("EnemyFire");
    }
}
