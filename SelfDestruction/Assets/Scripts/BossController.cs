using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    public Animator bossAnimator;


    // Start is called before the first frame update
    void Start()
    {
        BossFight(300);
    }

    void GoLeft()
    {
        bossAnimator.SetTrigger("GoLeft");
    }

    void GoRight()
    {
        bossAnimator.SetTrigger("GoRight");
    }

    public void BossFight(float duration)
    {
        StartCoroutine(BossMove(duration));
    }

    IEnumerator BossMove(float duration)
    {
        yield return new WaitForSeconds(3);
        GoLeft();
        yield return new WaitForSeconds(3);
        GoRight();
    }


        //private void Start()
        //{
        //    StartTimer(3);
        //}

        //public void StartTimer(float duration)
        //{
        //    StartCoroutine(RunTimer(duration));
        //}

        //private IEnumerator RunTimer(float duration)
        //{
        //    yield return new WaitForSeconds(duration);
        //    Debug.Log("EVENT!");
        //}
}
