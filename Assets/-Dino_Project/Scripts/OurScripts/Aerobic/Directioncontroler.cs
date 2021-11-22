using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Directioncontroler : MonoBehaviour
{
    [SerializeField] private Text feedback, scoreUIcanvas;
    [SerializeField] private SpriteRenderer activator;
    private bool intime = false;
    private float timeControler = 2f;
    [SerializeField] private float timereference, ITime, gameSpeed;
    [SerializeField]private int life, finalScore, score, direction, easy, hard, expert;
    private int scoreUI;
    private int controlerNumber;
    [SerializeField] private GameObject DefaultSing, PunchBagD, PunchBagE, PunchBagF;
    private DataHolder dt;
    [SerializeField]private Animator anim;

    private void Start()
    {
        activator = GetComponent<SpriteRenderer>();
        Default();
        dt = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        score = 0;
    }

    private void Update()
    {
        TimeControler();
        if (intime == true)
        {
            Direction();
            StartCoroutine(DisableInTime());
            controlerNumber = Direction();
            GameOver();
            anim.SetBool("Right", false);
            anim.SetBool("Left", false);
            anim.SetBool("Down", false);
            PunchBagD.SetActive(false);
            PunchBagE.SetActive(false);
            PunchBagF.SetActive(false);
        }
    }
    private IEnumerator DisableInTime()
    {
        ITime = timereference;
        yield return new WaitForSeconds(ITime -= 1f);
        if (direction == 1)
        {
            PunchBagE.SetActive(true);
        }
        if (direction == 2)
        {
            PunchBagF.SetActive(true);
        }
        if (direction == 3)
        {
            PunchBagD.SetActive(true);
        }
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

    public void PlayerLife()
    {        
        life--;
    }

    public void DirSelectRigth()
    {
        if (controlerNumber == 3)
        {
            TimeSpeedUp();
            score++;
            scoreUI++;
            anim.SetBool("Right", true);
        }
        else { feedback.text = "OOOOOH!"; PlayerLife(); }
        return;
    }
    public void DirSelectDown()
    {
        if (controlerNumber == 2)
        {
            TimeSpeedUp();
            score++;
            scoreUI++;
            anim.SetBool("Down", true);
        }
        else { feedback.text = "OOOOOH!"; PlayerLife(); }
        return;
    }
    public void DirSelectLeft()
    {
        if (controlerNumber == 1)
        {
            TimeSpeedUp();
            score++;
            scoreUI++;
            anim.SetBool("Left", true);
        }
        else { feedback.text = "OOOOOH!"; PlayerLife(); }
        return;
    }

    private void GameOver()
    {
        if (life <= 0)
        {
            ScoreChecker();
            dt.resistencia += finalScore;
            feedback.text = "GAME OVER";
            gameObject.SetActive(false);
        }
    }

    private int ScoreChecker()
    {
        if (score >= easy && score < hard)
        {
            finalScore = 1;
        }
        if (score >= hard && score < expert)
        {
            finalScore = 2;
        }
        if (score >= expert)
        {
            finalScore = 3;
        }
        return finalScore;
    }    
}
