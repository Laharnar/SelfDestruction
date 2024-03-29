﻿using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 0.5f;
    public GameObject Splash;
    public int damage = 1;
    public string ignoreTag = "Player";
    public bool isPlayerBullet = true;

    private void Start() {
        if(isPlayerBullet)
            GameObject.FindWithTag("Player").GetComponent<HealthController>().Damage(1);
        Destroy(gameObject, 2);
    }

    private void Update()
    {
        transform.Translate(new Vector2(0, bulletSpeed));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Instantiate(Splash, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Boss" && ignoreTag != "Boss")
        {
            Instantiate(Splash, transform.position, transform.rotation);
            collision.gameObject.GetComponent<HealthController>().Damage(1);
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Player" && ignoreTag != "Player") {
            Instantiate(Splash, transform.position, transform.rotation);
            collision.gameObject.GetComponent<HealthController>().Damage(1);
            Destroy(gameObject);

        }
    }
}