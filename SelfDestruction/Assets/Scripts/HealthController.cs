﻿using System.Collections;
using UnityEngine;

public class HealthController:MonoBehaviour {
    public int health=5;
    public bool beInvulnerableOnHit = true;
    public float onHitInvulnerabilityDuration = 1;
    public Transform invulnerabilitySpriteTarget;// which sprite should dissapear when invulnerable

    private void OnCollisionEnter2D(Collision2D collision) {
        Bullet bullet = collision.transform.GetComponent<Bullet>();
        if (bullet != null) {
            Damage(bullet.damage);
        }
    }

    public void Damage(int amount) {
        health -= amount;
        if (health <= 0) {
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