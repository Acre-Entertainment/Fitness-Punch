using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DisplayMessageForTimeThenActivateEvent : MonoBehaviour
{
    public string mensagem;
    public float tempoDaMensagem;
    public Text text;
    public UnityEvent onMensagemEnd;
    void Start()
    {
        text.text = mensagem;
        StartCoroutine(WaitToExecute());
    }
    private IEnumerator WaitToExecute()
    {
        yield return new WaitForSeconds(tempoDaMensagem);
        onMensagemEnd.Invoke();
    }
}
