using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Directioncontroler : MonoBehaviour
{
    [SerializeField] private Text feedback, scoreUIcanvas;
    [SerializeField] private SpriteRenderer activator;
    private bool intime = false;
    private float timeControler = 1.5f;
    [SerializeField] private float timereference, ITime, gameSpeed;
    [SerializeField]private int life, finalScore, score, direction, easy, hard, expert;
    private int scoreUI;
    private int controlerNumber;
    [SerializeField] private GameObject DefaultSing;
    private GameObject scoreDH;

    void Start()
    {
        activator = GetComponent<SpriteRenderer>();
        Default();
        scoreDH = GameObject.FindWithTag("DataHolder");
        score = 0;
    }

    void Update()
    {
        TimeControler();
        if (intime == true)
        {
            Direction();
            StartCoroutine(DisableInTime());
            controlerNumber = Direction();
            GameOver();
        }
    }
    private IEnumerator DisableInTime()
    {
        ITime = timereference;
        yield return new WaitForSeconds(ITime -= 0.3f);
        DefaultSing.SetActive(true);
    }

    protected int Right()
    {
        activator.color = Color.green;
        return 3;
    }
    protected int Down()
    {
        activator.color = Color.yellow;
        return 2;
    }
    protected int Left()
    {
        activator.color = Color.red;
        return 1;
    }
    private void Default()
    {
        activator.color = Color.blue;
    }

    public int Direction()
    {
        direction = (int)Random.Range(1, 4);

        if (direction == 3)
        {
            Right();
            intime = false;
        }
        if (direction == 2)
        {
            Down();
            intime = false;
        }
        if (direction == 1)
        {
            Left();
            intime = false;
        }
        scoreUIcanvas.text = "Score: " + scoreUI;
        return direction;
    }

    private void TimeControler()
    {
        if (timeControler > 0f && intime == false)
        {
            timeControler -= Time.deltaTime;
        }
        else
        {
            timeControler = timereference;
            intime = true;
        }
        if (timereference == 1.0f)
        {
            DefaultSing.SetActive(true);
        }
    }

    private void TimeSpeedUp()
    {
        timereference = timereference -= timereference *= gameSpeed;
    }

    private void PlayerLife()
    {        
        life--;
    }

    public void DirSelectRigth()
    {
        if (controlerNumber == 3)
        {
            feedback.text = "BOOYA!!!";
            TimeSpeedUp();
            score++;
            scoreUI++;
        }
        else { feedback.text = "OOOOOH!"; PlayerLife(); }
        return;
    }
    public void DirSelectDown()
    {
        if (controlerNumber == 2)
        {
            feedback.text = "BOOYA!!!";
            TimeSpeedUp();
            score++;
            scoreUI++;
        }
        else { feedback.text = "OOOOOH!"; PlayerLife(); }
        return;
    }
    public void DirSelectLeft()
    {
        if (controlerNumber == 1)
        {
            feedback.text = "BOOYA!!!";
            TimeSpeedUp();
            score++;
            scoreUI++;
        }
        else { feedback.text = "OOOOOH!"; PlayerLife(); }
        return;
    }

    private void GameOver()
    {
        if (life <= 0)
        {
            feedback.text = "GAME OVER";
            Destroy(gameObject);
        }
    }

    private int ScoreChecker()
    {
        if (score == easy)
        {
            finalScore = 1;
        }

        if (score == hard)
        {
            finalScore = 2;
        }

        if (score == expert)
        {
            finalScore = 3;
        }
        return finalScore;
    }
}
