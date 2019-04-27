using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed = 0.5f;
    private void Start() {
        Destroy(gameObject, 10);
    }

    private void Update() {
        transform.Translate(new Vector2(0, bulletSpeed));

    }
}