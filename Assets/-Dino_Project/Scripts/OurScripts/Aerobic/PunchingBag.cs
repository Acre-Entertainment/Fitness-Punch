using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingBag : MonoBehaviour
{
    private Directioncontroler Dc;
    [SerializeField]private GameObject impact;
    private void Start()
    {
        Dc = GameObject.FindGameObjectWithTag("Activator").GetComponent<Directioncontroler>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.Equals("Player"))
        {
            Dc.PlayerLife();
        }
        impact.SetActive(true);
        StartCoroutine(WhaitForIt());
    }
    private IEnumerator WhaitForIt()
    {
        yield return new WaitForSeconds(0.34f);
        impact.SetActive(false);
    }
}
