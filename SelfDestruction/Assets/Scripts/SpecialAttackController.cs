using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttackController : MonoBehaviour
{

    public GameObject forceField;
    public GameObject Boss;
    private HealthController healthcontroller;
    // Start is called before the first frame update
    void Start()
    {
        Boss = GameObject.FindGameObjectWithTag("Boss");
        healthcontroller = Boss.GetComponent<HealthController>();
        healthcontroller.Damage(5);
        GameObject.FindWithTag("Player").GetComponent<HealthController>().Damage(5);
        forceField.transform.position = Boss.transform.position;
        Destroy(gameObject, 2);
    }
}
