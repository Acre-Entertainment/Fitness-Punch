using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectSpawner : MonoBehaviour
//spawna objetos dentro de um square collider 2D aleatoriamente de acordo com a lista de objetos e suas weights de chance
{
    public GameObject[] objectsToSpawn;
    public int[] randomChanceWeight;
    //esses duas matrixes tem que ter a mesma quantidade de items dentro
    [SerializeField] private float timeInterval;
    [SerializeField] private bool limitedSpawn;
    [SerializeField] private int limitedSpawnQuantity = 1;
    private BoxCollider2D bc;
    private bool _timeToSpawn;
    private float _x, _y, _time;
    private int _randomSum, _randomMarker, _random, _spawnedObjects;
    public UnityEvent onLimitedSpawnEnd;
    void Start()
    {
        bc = gameObject.GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        _time = _time + 1 * Time.deltaTime;
        if(_time >= timeInterval)
        {
            foreach(int item in randomChanceWeight)
            {
                _randomSum = _randomSum + item;
            }
            _randomMarker = Random.Range(0, _randomSum);
            _randomSum = 0;
            for(int i = 0; _randomMarker >= _randomSum; i++)
            {
                _randomSum = _randomSum + randomChanceWeight[i];
                _random = i;
            }
            //o codigo acima seleciona um objeto aleatorio de acordo com o weight deles
            _randomMarker = 0;
            _randomSum = 0;
            _x = Random.Range(gameObject.transform.position.x - bc.size.x/2, gameObject.transform.position.x + bc.size.x/2);
            _y = Random.Range(gameObject.transform.position.y - bc.size.y/2, gameObject.transform.position.y + bc.size.y/2);
            Instantiate(objectsToSpawn[_random], new Vector3(_x, _y, 0), Quaternion.identity);
            _time = 0;
            if(limitedSpawn == true)
            {
                _spawnedObjects++;
                if(limitedSpawnQuantity == _spawnedObjects)
                {
                    onLimitedSpawnEnd.Invoke();
                    Destroy(gameObject);
                }
            }
        }
    }
}
