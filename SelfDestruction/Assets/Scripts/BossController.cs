using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossAction {
    UpLeft,
    UpRight,
    DownLeft,
    DownRight,
    HorizontalLeft,
    HorizontalRight,
    Wait1,
    Wait2,
    Wait5,
    Shoot1,
    Shoot2
}
public class BossController : MonoBehaviour
{

    public Animator bossAnimator;
    public BossAction[] bossScript;

    bool waitAnimationEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        BossFight(300);
    }

    void GoUpLeft()
    {
        bossAnimator.SetTrigger("GoUpLeft");
    }

    void GoUpRight()
    {
        bossAnimator.SetTrigger("GoUpRight");
    }

    void GoDownLeft() {
        bossAnimator.SetTrigger("GoDownLeft");
    }

    void GoDownRight() {
        bossAnimator.SetTrigger("GoDownRight");
    }
    void GoHorizontalLeft() {
        bossAnimator.SetTrigger("GoHorizontalLeft");
    }

    void GoHorizontalRight() {
        bossAnimator.SetTrigger("GoHorizontalRight");
    }
    public void BossFight(float duration)
    {
        StartCoroutine(BossMove(duration));
    }

    public IEnumerator ExecuteScript(params BossAction[] directions) {
        for (int i = 0; i < directions.Length; i++) {
            yield return StartCoroutine(ExecuteSingleCommand(directions[i]));
            while (waitAnimationEnd) {
                yield return null;
            }
        }
        yield return null;
    }

    // Triggered directly by action in animations.
    public void AnimationsEndAnimation() {
        waitAnimationEnd = false;
    }

    private IEnumerator ExecuteSingleCommand(BossAction bossDirections) {
        waitAnimationEnd = true;
        switch (bossDirections) {
            case BossAction.UpLeft:
                GoUpLeft();
                break;
            case BossAction.UpRight:
                GoUpRight();
                break;
            case BossAction.DownLeft:
                GoDownLeft();
                break;
            case BossAction.DownRight:
                GoDownRight();
                break;
            case BossAction.HorizontalLeft:
                GoHorizontalLeft();
                break;
            case BossAction.HorizontalRight:
                GoHorizontalRight();
                break;
            case BossAction.Wait1:
                yield return new WaitForSeconds(1);
                waitAnimationEnd = false;

                break;
            case BossAction.Wait2:
                yield return new WaitForSeconds(2);
                waitAnimationEnd = false;
                break;
            case BossAction.Wait5:
                yield return new WaitForSeconds(5);
                waitAnimationEnd = false;
                break;
            default:
                break;
        }
        yield return null;
    }

    IEnumerator BossMove(float duration)
    {
        while (true) {
            yield return StartCoroutine(ExecuteScript(bossScript));
        }
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
