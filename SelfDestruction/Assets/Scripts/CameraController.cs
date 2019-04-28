using UnityEngine;

public class CameraController:MonoBehaviour {
    public BossController boss;
    public Player player;
    public Animator anim;
    int cameraStage;

    private void Update() {
        
        if (boss) {

            int x = boss.bossStage;
            if (x > cameraStage) {
                MoveCameraToNextStage();
                MovePlayerToNextStage();
                MoveBossToNextStage();
            }

        } else {
            Debug.Log("Assign the boss.");
        }
    }

    public void MoveCameraToNextStage() {
        anim.SetTrigger("CameraUp");
    }

    public void MovePlayerToNextStage() {
        Debug.Log("TODO");
    }

    public void MoveBossToNextStage() {
        Debug.Log("TODO");
    }
}
