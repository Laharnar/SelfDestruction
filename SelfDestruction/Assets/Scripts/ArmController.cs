using System;
using System.Collections.Generic;
using UnityEngine;

public class ArmController:MonoBehaviour {

    public Transform armRoot;// rotate this
    public Transform armObject;
    public Transform armSpawnPoint;
    public Player player;

    public Transform bullet;
    public Transform specialAttack;
    List<Transform> spawnedBullets = new List<Transform>();

    private void Update() {
        for (int i = 0; i < spawnedBullets.Count; i++) {
            if (spawnedBullets[i] == null) {
                spawnedBullets.RemoveAt(i);
                i--;
            }
        }
    }

    public void UpdateArmDirection(Vector2 aimPt, bool turn) {
        if (!turn) {
            armRoot.right = aimPt - (Vector2)transform.position;
        }
        else armRoot.right =  -aimPt + (Vector2)transform.position;
        //else
        //   armRoot.right = -aimPt;
    }

    // Use in other scripts
    public void Fire() 
    {
        Transform t = Instantiate(bullet, armSpawnPoint.position, armSpawnPoint.rotation);
        spawnedBullets.Add(t);
    }

    public void SpecialAttack()
    {
        Transform t = Instantiate(specialAttack, armSpawnPoint.position, armSpawnPoint.rotation);
    }
}
