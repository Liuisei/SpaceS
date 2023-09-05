using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAI : MonoBehaviour
{
    [SerializeField] GameObject[] _gameObjects;
    [SerializeField] float _spawnSpeed = 1f;
    
    bool _playerIn = false;
    bool _canSpawn = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMove>(out _))
        {
            _playerIn = true;
            Debug.Log("PLAYERIN" + _playerIn);
        }
    }
    private void Update()
    {
        if (_playerIn == true && _canSpawn == true)
        {
            _canSpawn = false;
            StartCoroutine(SpawnEnemyCooldown());
        }
    }


    private IEnumerator SpawnEnemyCooldown()
    {
        SpawnEnemy(_gameObjects[0]);
        yield return new WaitForSeconds(_spawnSpeed);
        _canSpawn = true;
    }

    public void SpawnEnemy(GameObject gameObject)
    {
        GameObject newEnemy = Instantiate(gameObject, transform);
        newEnemy.transform.parent = null;

    } 


}
