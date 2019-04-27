using UnityEngine;

public class GroundScript:MonoBehaviour {
    public Transform groundCollision;
    private void Start() {
        groundCollision.tag = "Ground";
    }
}