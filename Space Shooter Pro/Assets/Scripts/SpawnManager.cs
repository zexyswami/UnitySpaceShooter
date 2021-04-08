using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private float _spawnTime = 5f;
    private bool _stopSpawning = false;
    [SerializeField]
    private GameObject[] _powerups;
   
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine(_spawnTime));
        StartCoroutine(SpawnPowerupRoutine());
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    
    //create a coroutine of type IEnumerator -- Yield Events
    IEnumerator SpawnEnemyRoutine (float time)
    {
        while (_stopSpawning == false)
        {
            float spawnPosition = Random.Range(-8f, 8f);
            GameObject newEnemy = Instantiate(_enemyPrefab, new Vector3(spawnPosition, 7.31f, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(time); 
        }
    }

    IEnumerator SpawnPowerupRoutine ()
    {
        while(_stopSpawning == false)
        {
            int randomPowerUp = Random.Range(0,3);
            float spawnPosition = Random.Range(-8f, 8f);
            int powerupSpawn = Random.Range(3, 7);
            yield return new WaitForSeconds(powerupSpawn);
            Instantiate(_powerups[randomPowerUp], new Vector3(spawnPosition, 7.31f, 0), Quaternion.identity);
        }
    }
    
    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
