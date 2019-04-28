using System;
using System.Collections;
using UnityEngine;

public class HealthController:MonoBehaviour {
    public float health=100;
    public bool beInvulnerableOnHit = true;
    public float onHitInvulnerabilityDuration = 1;
    public Transform invulnerabilitySpriteTarget;// which sprite should dissapear when invulnerable
    public GameObject deathFX;
    public float maxHealth;
    public Animator animator;
    public string onDeathTriggerOnAnimation;

    private void Start()
    {
        maxHealth = health;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        Bullet bullet = collision.transform.GetComponent<Bullet>();
        if (bullet != null && bullet.ignoreTag != transform.root.tag) {
            Damage(bullet.damage);
        }
    }

    public void Damage(int amount) {
        health -= amount;
        if (health <= 0) {
            if (animator)
                animator.SetTrigger(onDeathTriggerOnAnimation);
            Instantiate(deathFX, transform.position, transform.rotation);
            Destroy(gameObject);
        } else if (beInvulnerableOnHit) {
            StartCoroutine(Invincibility());
        }
    }

    IEnumerator Invincibility() {
        for (float i = 0; i < onHitInvulnerabilityDuration; i+=0.5f) {
            invulnerabilitySpriteTarget.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.25f);
            invulnerabilitySpriteTarget.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.25f);
        }
        yield return new WaitForSeconds(onHitInvulnerabilityDuration);
    }
}
