using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed = 0.5f;
    public GameObject Splash;
    private void Start()
    {
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        transform.Translate(new Vector2(0, bulletSpeed));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Ground")
        {
            Instantiate(Splash, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}