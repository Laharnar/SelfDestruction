﻿using System;
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

        Vector3 aimPt = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("AimPt "+aimPt);
        UpdateArmDirection(aimPt);
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            SpecialAttack();
        }
    }



    private void UpdateArmDirection(Vector2 aimPt) {
        armRoot.right =  aimPt - (Vector2)transform.position;
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
