using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController:MonoBehaviour {
    public BossController boss;
    public Animator anim;
    int cameraStage;

    private void Start() {
        if (boss == null) {
            boss = GameObject.FindObjectOfType<BossController>();
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("Grave Scene"); }
          
        if (boss) {

            int x = boss.bossStage;
            if (x > cameraStage) {
                cameraStage = x;
                MoveCameraToNextStage();
            }

        } else {
            Debug.Log("Assign the boss.");
        }
    }

    public void MoveCameraToNextStage() {
        anim.SetTrigger("CameraUp");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.root.tag == "Player") {
            other.transform.root.GetComponent<HealthController>().Damage(999999999);
        }
    }
}
