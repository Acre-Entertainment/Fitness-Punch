using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	public static GameControl instance = null;

	[SerializeField]
	GameObject restartButton;

	[SerializeField]
	Text highScoreText;

	[SerializeField]
	Text yourScoreText;

	[SerializeField]
	GameObject[] obstacles;

	[SerializeField]
	Transform spawnPoint;

	[SerializeField]
	float spawnRate = 2f;
	float nextSpawn;

	[SerializeField]
	public float timeToBoost = 10f;
	float nextBoost;

	int highScore = 0, yourScore = 0;
	[SerializeField] private int scoreNeededForExtraDisposition;

	public static bool gameStopped;
	[HideInInspector] public bool gamePaused;


	float nextScoreIncrease = 0f;

	private CharacterJump cj;
	private float gameTime;
	[HideInInspector] public int howManyTimesHasTimeBeenBosted;
	[SerializeField] private GameObject pauseObject;
	private DataHolder dataHolder;

	// Use this for initialization
	void Start () {
		
		if (instance == null) 
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		restartButton.SetActive (false);
		yourScore = 0;
		gameStopped = false;
		Time.timeScale = 1f;
		highScore = PlayerPrefs.GetInt ("Best Time");
		nextSpawn = Time.time + spawnRate;
		nextBoost = Time.time + timeToBoost;
		cj = GameObject.FindGameObjectWithTag("PlayerFun").GetComponent<CharacterJump>();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameStopped == false)
			IncreaseYourScore ();
		if(gamePaused == false)
		{
			gameTime = gameTime + 1 * Time.deltaTime;
		}

		highScoreText.text = "Melhor Tempo: " + highScore;
		yourScoreText.text = "Seu Tempo: " + yourScore;

		if (Time.time > nextSpawn)
			SpawnObstacle ();

		if (Time.time > nextBoost && !gameStopped)
			BoostTime ();
	}

	public void DinoHit()
	{
		cj.currentHealth = cj.currentHealth - 1;
		if(cj.currentHealth <= 0)
		{
			if (yourScore > highScore)
				PlayerPrefs.SetInt("highScore", yourScore);
			Time.timeScale = 0;
			gameStopped = true;
			restartButton.SetActive (true);
			pauseObject.SetActive(false);

			dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
			dataHolder.disposicao++;
			if(yourScore >= scoreNeededForExtraDisposition)
			{
				dataHolder.disposicao++;
			}
			if(dataHolder.disposicao > 10)
			{
				dataHolder.disposicao = 10;
			}
		}
	}

	void SpawnObstacle()
	{
		nextSpawn = Time.time + spawnRate;
		int randomObstacle = Random.Range (0, obstacles.Length);
		Instantiate (obstacles [randomObstacle], spawnPoint.position, Quaternion.identity);
	}

	void BoostTime()
	{
		howManyTimesHasTimeBeenBosted++;
		nextBoost = Time.time + timeToBoost;
		Time.timeScale += 0.25f;
	}

	void IncreaseYourScore()
	{
		if (gameTime > nextScoreIncrease) {
			yourScore += 1;
			nextScoreIncrease = gameTime + 1;
		}
	}

	public void RestartGame()
	{
		SceneManager.LoadScene ("Scene01");
	}

}
