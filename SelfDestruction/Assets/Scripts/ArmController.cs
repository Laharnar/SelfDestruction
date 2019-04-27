using System;
using System.Collections.Generic;
using UnityEngine;

public class ArmController:MonoBehaviour {

    public Transform armRoot;// rotate this
    public Transform armObject;
    public Transform armSpawnPoint;

    public Transform bullet;
    List<Transform> spawnedBullets = new List<Transform>();

    private void Update() {
        for (int i = 0; i < spawnedBullets.Count; i++) {
            if (spawnedBullets[i] == null) {
                spawnedBullets.RemoveAt(i);
                i--;
            }
        }

        Vector2 aimPt = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        UpdateArmDirection(aimPt);
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Fire();
        }
    }

    private void UpdateArmDirection(Vector2 aimPt) {
        armRoot.right = aimPt;
    }

    // Use in other scripts
    public void Fire() {
        Transform t= Instantiate(bullet, armSpawnPoint.position, armSpawnPoint.rotation);
        spawnedBullets.Add(t);
    }
}
