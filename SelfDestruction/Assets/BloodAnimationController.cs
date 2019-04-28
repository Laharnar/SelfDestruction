using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodAnimationController : MonoBehaviour
{
    public bool bloodWellFull = false;

    public void BloodFilled() {
        Debug.Log("BloodFilled");
        bloodWellFull = true;
    }
}
