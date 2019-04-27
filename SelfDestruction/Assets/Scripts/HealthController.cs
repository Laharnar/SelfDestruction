using UnityEngine;

public class HealthController:MonoBehaviour {
    public int health=5;

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
        }
    }
}
