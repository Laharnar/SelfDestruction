using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttackController : MonoBehaviour
{

    public GameObject forceField;
    public GameObject Boss;
    // Start is called before the first frame update
    void Start()
    {
        Boss = GameObject.FindGameObjectWithTag("Boss");
        forceField.transform.position = Boss.transform.position;
        Destroy(gameObject, 2);
    }
}
