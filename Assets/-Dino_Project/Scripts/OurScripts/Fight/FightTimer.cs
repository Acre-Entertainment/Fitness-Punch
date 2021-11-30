using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FightTimer : MonoBehaviour
{
    public Text text;
    public UnityEvent onGo; 
    void Start()
    {
        StartCoroutine(Two());
        StartCoroutine(One());
        StartCoroutine(Ready());
        StartCoroutine(Go());
        StartCoroutine(EndGame());
    }
    private IEnumerator Two()
    {
        yield return new WaitForSeconds(1);
        text.text = "2";
        FindObjectOfType<AudioManager>().Play("Countdown_two");
    }
    private IEnumerator One()
    {
        yield return new WaitForSeconds(2);
        text.text = "1";
        FindObjectOfType<AudioManager>().Play("Countdown_one");
    }
    private IEnumerator Ready()
    {
        yield return new WaitForSeconds(3);
        text.text = "Pronto?";
        FindObjectOfType<AudioManager>().Play("Countdown_ready");
    }
    private IEnumerator Go()
    {
        yield return new WaitForSeconds(4);
        text.text = "Vai!";
        FindObjectOfType<AudioManager>().Play("Countdown_fight");
        onGo.Invoke();
    }
    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}
