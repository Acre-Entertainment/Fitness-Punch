using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingBag : MonoBehaviour
{
    [SerializeField]private Directioncontroler Dc;
    [SerializeField]private GameObject impact;
    [SerializeField] private Animator anim;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Dc.PlayerLife();
        impact.SetActive(true);
        anim.SetBool("Damage", true);
        StartCoroutine(WhaitForIt());
    }
    private IEnumerator WhaitForIt()
    {
        yield return new WaitForSeconds(0.34f);
        impact.SetActive(false);
        anim.SetBool("Damage", false);
    }
}
