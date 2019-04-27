using UnityEngine;

public class Bullet : MonoBehaviour {
    private void Start() {
        Destroy(gameObject, 10);
    }
    private void Update() {

        transform.Translate(Vector2.up);

    }
}