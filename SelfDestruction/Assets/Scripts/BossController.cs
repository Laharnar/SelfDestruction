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
    ShootHeavy,
    ShootLight,
    AdditionalAction1,
    AdditionalAction2,
    AdditionalAction3,
    AdditionalAction4,
    AdditionalAction5,
    AdditionalAction6,
    AdditionalAction7,
    AdditionalAction8,
    AdditionalAction9
}
public class BossController : MonoBehaviour
{
    public float[] actionTimes = new float[20];
    public HealthController hp;
    public Animator bossAnimator;
    public Animator bloodAnimator;
    public Animator bouncingAnimator;
    public int startAt = 0;
    public ArmController gun;
    public List<BossAction> bossScript=new List<BossAction>();
    public BloodAnimationController bloodFill;

    bool waitAnimationEnd = false;
    internal int bossStage;

    Transform player;

    public Transform crosshairPrefab;
    public Transform crosshairExplosion;

    // Start is called before the first frame update
    void Start()
    {
        if (crosshairPrefab == null) {
            crosshairPrefab = new GameObject().transform;
        }
        player = GameObject.FindWithTag("Player").transform;
        BossFight(300);
    }

    private void Update() {
        if (Time.time > 2) {
            bossStage = 1;
        }
        if (Time.time > 4) {
            bossStage = 2;
        }

        bouncingAnimator.SetInteger("BounceAnimation", UnityEngine.Random.Range(0, 3));
    }

    #region movement
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
    #endregion

    public void BossFight(float duration)
    {
        StartCoroutine(BossMove(duration));
    }

    public IEnumerator ExecuteScript() {
        for (int i = startAt; i < bossScript.Count; i++) {
            yield return StartCoroutine(ExecuteSingleCommand(bossScript[i]));
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
            case BossAction.ShootHeavy:
                if (bloodFill.bloodWellFull) {
                    Transform shot = Instantiate(crosshairPrefab, player.transform.position, new Quaternion());

                    bloodFill.bloodWellFull = false;
                    yield return new WaitForSeconds(2);
                    bloodAnimator.SetTrigger("EmptyBlood");
                    Vector2 pos = shot.transform.position;

                    Destroy(shot.gameObject);
                    yield return new WaitForSeconds(0.1f);
                    shot = Instantiate(crosshairExplosion, pos, Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360)));
                    Destroy(shot.gameObject, 5);

                    ShootHeavy();
                }
                waitAnimationEnd = false;
                break;
            case BossAction.ShootLight:
                ShootLight();
                yield return new WaitForSeconds(0.2f);
                ShootLight();
                yield return new WaitForSeconds(0.2f);
                ShootLight();
                yield return new WaitForSeconds(0.2f);
                ShootLight();
                yield return new WaitForSeconds(0.2f);
                ShootLight();
                yield return new WaitForSeconds(0.2f);
                waitAnimationEnd = false;
                break;
            default:
                break;
        }
        yield return null;
    }

    void ShootLight() {
        gun.armRoot.up = -((Vector2)player.position - (Vector2)transform.position);
        gun.Fire();
    }

    void ShootHeavy() {
        gun.armRoot.up = -((Vector2)player.position - (Vector2)transform.position);

        //gun.SpecialAttack();
    }

    IEnumerator BossMove(float duration)
    {
        while (true) {
            yield return StartCoroutine(ExecuteScript());
        }
    }

    
}
