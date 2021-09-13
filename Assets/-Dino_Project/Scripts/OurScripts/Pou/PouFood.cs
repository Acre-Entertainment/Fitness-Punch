using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouFood : MonoBehaviour
{
    private Rigidbody2D rb;
    private PouGameMaster PGM;
    [SerializeField] private float restingXPosition;
    [SerializeField] private float restingYPosition;
    [SerializeField] private GameObject spawner;
    [SerializeField] private int foodQuality;
    [SerializeField] private float fallSpeed;
    [SerializeField] private float randomTimeToFall;
    [SerializeField] private int randomXPositionRange;
    private float _time;
    private float _timeToFall;
    private bool _isFalling = false;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        _time = 0;
        _timeToFall = Random.Range(0, randomTimeToFall);
        _isFalling = false;
    }

    void Update()
    {
        if(_isFalling == false)
        {
            _time = _time + 1 * Time.deltaTime;
        }
        if(_time >= _timeToFall && _isFalling == false)
        {
            _isFalling = true;
            putInRandomPositionInsideSpawnerAndThenStartFalling();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            PGM = GameObject.FindWithTag("GameMaster").GetComponent<PouGameMaster>();
            switch(foodQuality)
            {
                case 1:
                    PGM.lowQualityFoodCatched++;
                    break;
                case 2:
                    PGM.mediumQualityFoodCatched++;
                    break;
                case 3:
                    PGM.highQualityFoodCatched++;
                    break;
            }
            restart();
        }
        if(other.gameObject.tag == "Respawn")
        {
            restart();
        }
    }

    public void putInRandomPositionInsideSpawnerAndThenStartFalling()
    {
        gameObject.transform.position = new Vector3(spawner.transform.position.x + Random.Range(-randomXPositionRange, randomXPositionRange), spawner.transform.position.y, spawner.transform.position.z);
        rb.velocity = new Vector2(0, -fallSpeed);
    }
    public void restart()
    {
        gameObject.transform.position = new Vector3(restingXPosition, restingYPosition, 0);
        _time = 0;
        _timeToFall = Random.Range(0, randomTimeToFall);
        _isFalling = false;
    }
}
